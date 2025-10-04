using UnityEngine;

public class MazeHole : MonoBehaviour
{

    private Maze maze;
    public int number;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maze = transform.parent.GetComponent<Maze>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        maze.onBallExit(number);
    }
}
