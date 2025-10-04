using UnityEngine;

public class Maze : MonoBehaviour
{
    public Transform spawnLocation;
    private NarrativeController narrativeController;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        narrativeController = GameObject.Find("GameController").GetComponent<NarrativeController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBallExit(int number)
    {
        narrativeController.MazeCompleted(number);
    }
}
