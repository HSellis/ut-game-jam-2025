using UnityEngine;

public class MazeHole : MonoBehaviour
{
    public GameObject optionIndicatorPrefab;
    private Color[] optionColors = { Color.blue, Color.green, Color.yellow };

    private Maze maze;
    public int number;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maze = transform.parent.GetComponent<Maze>();
        GameObject optionIndicator = Instantiate(optionIndicatorPrefab, transform);
        optionIndicator.GetComponent<MeshRenderer>().material.color = optionColors[number];
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
