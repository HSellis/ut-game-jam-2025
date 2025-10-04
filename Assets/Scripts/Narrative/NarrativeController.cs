using UnityEngine;

public class NarrativeController : MonoBehaviour
{
    public MazeController mazeController;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
