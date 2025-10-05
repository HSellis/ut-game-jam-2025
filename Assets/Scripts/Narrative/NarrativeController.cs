using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NarrativeController : MonoBehaviour
{
    public static NarrativeController Instance { get; private set; }
    public DialogueNode currentDialogueNode;

    public MazeController mazeController;
    public UIController UIController;

    private string endingSceneName = "EndScreen";

    private int activeCharacterIndex = 0;
    private int[] totalRizzScores = new int[2];
    private int currentRizz = 0;

    private Dictionary<DialogueOptionResult, int> resultToDelta = new Dictionary<DialogueOptionResult, int> 
    {
        {DialogueOptionResult.POSITIVE, 5},
        {DialogueOptionResult.NEUTRAL, 0},
        {DialogueOptionResult.NEGATIVE, -3}

    };
    private Dictionary<int, int> characterRizzThresholds = new Dictionary<int, int>
    {
        {0, 10 },
        {1, 10},
    };

    private Dictionary<string, int> sceneToCharacterIndex =
    new Dictionary<string, int>
    {
            {"MainScene", 0},
            {"MainScene2", 1}
    };

    

    void Awake()
    {
        activeCharacterIndex = sceneToCharacterIndex[SceneManager.GetActiveScene().name];
        Debug.Log("Active character index: " + activeCharacterIndex.ToString());


        if (Instance != null && Instance != this)
        {
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

    public void AddRizz(int value)
    {
        currentRizz += value;
        UIController.UpdateRizzCounter(currentRizz);
    }

    public void StartDialogue()
    {
        LoadDialogueNode(currentDialogueNode);
    }

    private void LoadDialogueNode(DialogueNode node)
    {
        if (node == null || currentDialogueNode.IsFinalNode)
        {
            LoadNextCharacter();
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

        int who = activeCharacterIndex;

        Debug.Log(who);
        AddRizz(resultToDelta[currentDialogueNode.playerChoices[selectedOptionNumber].result]);

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

    private void LoadNextCharacter()
    {
        totalRizzScores[activeCharacterIndex] = currentRizz;
        currentRizz = 0;

        // TODO: load next character's scene
        SceneManager.LoadScene(endingSceneName);
    }

    public int GetEndingNumber()
    {
        bool success = true;
        for (int i = 0; i < totalRizzScores.Length; i++)
        {
            if (totalRizzScores[i] < characterRizzThresholds[i])
            {
                success = false;
            }
        }
        return success ? 1 : 0;
    }

}
