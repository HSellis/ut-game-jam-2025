using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-1000)]
public class NarrativeController : MonoBehaviour
{
    public static NarrativeController Instance { get; private set; }
    public DialogueNode currentDialogueNode;

    public MazeController mazeController;
    public UIController UIController;

    // Neid võib vahetada kui tundub liiga kerge/raske
    public int goodThreshold = 5;
    public int neutralThreshold = 3;
    public string endingSceneName = "EndScreen";

    // Eeldades et 1 karakterit on, tee suuremaks kui rohkem
    private int[] scores = new int[1];
    private bool[] routeFinished = new bool[1];
    private int finishedCount = 0;

    private Dictionary<DialogueOptionResult, int> resultToDelta = 
        new Dictionary<DialogueOptionResult, int> 
        {
            {DialogueOptionResult.POSITIVE, 1},
            {DialogueOptionResult.NEUTRAL, 0},
            {DialogueOptionResult.NEGATIVE, -1}

        };

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.Log("DESTROYING NARRATIVE CONTROLLER");
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialogue()
    {
        LoadDialogueNode(currentDialogueNode);
    }

    private void LoadDialogueNode(DialogueNode node)
    {
        if (node == null || currentDialogueNode.IsFinalNode)
        {
            TryFinishRoute();
            return;
        }
        UIController.LoadDialogueNode(node);

        if (node.requireMinigame)
        {
            mazeController.SpawnMaze(node.playerChoices.Count);
        }

        currentDialogueNode = node;
    }

    public void SelectDialogueOption(int selectedOptionNumber)
    {
        UIController.ShowDialogResult(currentDialogueNode.playerChoices[selectedOptionNumber].result);

        int who = currentDialogueNode.characterIndex;
        scores[who] = scores[who] + resultToDelta[currentDialogueNode.playerChoices[selectedOptionNumber].result];

        DialogueNode nextDialogueNode = currentDialogueNode.playerChoices[selectedOptionNumber].nextDialogueNode;

        if (currentDialogueNode.requireMinigame) {
            StartCoroutine(RemoveMazeWithDelay(1f));
            StartCoroutine(ProgressDialogueWithDelay(3.5f, nextDialogueNode));
        } else {
            LoadDialogueNode(nextDialogueNode);
        }
    }

    IEnumerator RemoveMazeWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        mazeController.RemoveMaze();
    }

    IEnumerator ProgressDialogueWithDelay(float delay, DialogueNode dialogNode)
    {
        yield return new WaitForSeconds(delay);
        LoadDialogueNode(dialogNode);
    }

    private void TryFinishRoute()
    {
        int who = currentDialogueNode.characterIndex;

        if (!routeFinished[who])
        {
            routeFinished[who] = true;
            finishedCount++;
        }

        Debug.Log(finishedCount);
        // Kui kõik tegelased on teinud dialoguei ära kui 2 korda on dialogue lõppu jõudnud
        if (finishedCount >= 1)
        {
            Debug.Log("Try open ending scene");
            SceneManager.LoadScene(endingSceneName);
        }
        else
        {
            // TODO: Go to next character scene, not to same character again
            SceneManager.LoadScene("MainScene");
        }
    }

    public string GetEndingPanelName()
    {
        int numGood = scores.Count(v => v >= goodThreshold);
        int numNeutral = scores.Count(v => v >= neutralThreshold && v < goodThreshold);

        if (numGood == scores.Length) return "Good_Ending_Panel";
        if (numGood > 0 || numNeutral > 0) return "Neutral_Ending_Panel";
        return "Bad_Ending_Panel";
    }

}
