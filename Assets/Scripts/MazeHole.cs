using UnityEngine;

public class MazeHole : MonoBehaviour
{
    private Color[] optionColors = { Color.blue, Color.green, Color.yellow };

    private Maze maze;
    public int number;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maze = transform.parent.GetComponent<Maze>();
        MazeExitIndicator exitIndicator = Instantiate(maze.exitIndicatorPrefab, transform.position, maze.exitIndicatorPrefab.transform.rotation);
        exitIndicator.mazeHole = this;
        exitIndicator.color = optionColors[number];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Ball ball = other.GetComponent<Ball>();
        if (ball != null)
        {
            CompleteMaze();
        }
    }

    private void CompleteMaze()
    {
        maze.OnBallExit(number);
    }
}
