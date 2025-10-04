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
        UIController.LoadDialogueNode(currentDialogueNode);
    }

    public void ProgressDialogue(int playerTextOptionNumber)
    {
        DialogueNode nextDialogueNode = currentDialogueNode.playerChoices[playerTextOptionNumber].nextDialogueNode;
        UIController.LoadDialogueNode(nextDialogueNode);
        currentDialogueNode = nextDialogueNode;
    }

    public void BringMaze()
    {
        mazeController.EnableMaze();
    }

    public void MoveAwayMaze()
    {
        mazeController.DisableMaze();
    }

    public void MazeCompleted(int exitNumber)
    {
        MoveAwayMaze();
    }
}
