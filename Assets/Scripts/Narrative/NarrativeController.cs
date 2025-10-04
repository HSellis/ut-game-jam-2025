using System.Collections;
using UnityEngine;

public class NarrativeController : MonoBehaviour
{
    public DialogueNode currentDialogueNode;

    public MazeController mazeController;
    public UIController UIController;
    

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

}
