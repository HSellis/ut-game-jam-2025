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

    public void ProgressDialogue(int selectedOptionNumber)
    {
        DialogueNode nextDialogueNode = currentDialogueNode.playerChoices[selectedOptionNumber].nextDialogueNode;
        LoadDialogueNode(nextDialogueNode);
        
    }

    public void MazeCompleted(int exitNumber)
    {
        mazeController.DisableMaze();
        ProgressDialogue(exitNumber);
    }
}
