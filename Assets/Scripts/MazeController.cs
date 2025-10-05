using DG.Tweening;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using UnityEngine;

public class MazeController : MonoBehaviour
{
    public Maze[] oneExitMazes;
    public Maze[] twoExitMazes;
    public Maze[] threeExitMazes;

    public Ball ballPrefab;
    public RizzOrb rizzOrbPrefab;

    private Ball ball;
    private Maze currentMaze;

    public float rotationSpeed = 10;
    public float animationSpeed = 2;
    public float rizzOrbCount = 5;
    public float rizzOrbSpawnDistance = 4;

    public Vector3 upPosition;
    public Vector3 downPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentMaze = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentMaze != null)
        {
            if (Input.GetKey(KeyCode.W))
            {
                currentMaze.transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.S))
            {
                currentMaze.transform.Rotate(Vector3.left, rotationSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.A))
            {
                currentMaze.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.D))
            {
                currentMaze.transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
            }
        }
    }


    public void SpawnMaze(int exitHolesNumber)
    {
        Maze[] possibleMazes;
        if (exitHolesNumber == 1)
        {
            possibleMazes = oneExitMazes;
        } else if (exitHolesNumber == 2)
        {
            possibleMazes = twoExitMazes;
        } else
        {
            possibleMazes = threeExitMazes;
        }


        int randomIndex = UnityEngine.Random.Range(0, possibleMazes.Length);
        Maze selectedMaze = possibleMazes[randomIndex];
        currentMaze = Instantiate(selectedMaze, downPosition, Quaternion.identity);

        currentMaze.transform.DOMove(upPosition, animationSpeed);
        Invoke("SpawnBall", animationSpeed + 0.5f);
        Invoke("SpawnRizzOrbs", animationSpeed + 0.5f);

    }

    public void RemoveMaze()
    {
        Destroy(ball.gameObject);
        ball = null;
        currentMaze.transform.DOMove(downPosition, animationSpeed);
        Invoke("DestroyMaze", animationSpeed);
    }

    private void SpawnBall()
    {
        ball = Instantiate(ballPrefab, currentMaze.spawnLocation.position, Quaternion.identity);
    }

    private void SpawnRizzOrbs()
    {
        for (int i = 0; i < rizzOrbCount; i++)
        {
            float offsetX = UnityEngine.Random.Range(-rizzOrbSpawnDistance, rizzOrbSpawnDistance);
            float offsetZ = UnityEngine.Random.Range(-rizzOrbSpawnDistance, rizzOrbSpawnDistance);

            Vector3 rizzOrbPos = currentMaze.transform.position + new Vector3(offsetX, 3, offsetZ);
            Instantiate(rizzOrbPrefab, rizzOrbPos, Quaternion.identity);
        }
    }

    private void DestroyMaze()
    {
        Destroy(currentMaze.gameObject);
        currentMaze = null;
    }
}
