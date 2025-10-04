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
            mazeController.EnableMaze();
        }

        currentDialogueNode = node;
    }

    public void SelectDialogueOption(int selectedOptionNumber)
    {
        if (currentDialogueNode.requireMinigame)
        {
            UIController.SelectTextOption(selectedOptionNumber);
            mazeController.DisableMaze();
        }
        
        DialogueNode nextDialogueNode = currentDialogueNode.playerChoices[selectedOptionNumber].nextDialogueNode;

        if (currentDialogueNode.requireMinigame) {
            // Wait 2 sec
            StartCoroutine(ProgressDialogueWithDelay(2f, nextDialogueNode));
        } else {
            LoadDialogueNode(nextDialogueNode);
        }
        
        
    }

    IEnumerator ProgressDialogueWithDelay(float delay, DialogueNode dialogNode)
    {
        yield return new WaitForSeconds(delay);
        LoadDialogueNode(dialogNode);
    }

}
