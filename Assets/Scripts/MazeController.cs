using DG.Tweening;
using UnityEngine;

public class MazeController : MonoBehaviour
{
    public Maze maze;
    public GameObject ball;
    private Transform mazeTransform;
    private Rigidbody ballRigidBody;

    public float rotationSpeed = 10;
    public float animationSpeed = 2;

    public float ballAccelerationRate = 20;

    public Vector3 upPosition;
    public Vector3 downPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mazeTransform = maze.transform;
        ballRigidBody = ball.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            mazeTransform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            mazeTransform.Rotate(Vector3.left, rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            mazeTransform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            mazeTransform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        
        float accelerationRateX = Mathf.Sin(mazeTransform.rotation.eulerAngles.x * Mathf.PI / 180);
        float accelerationRateZ = Mathf.Sin(mazeTransform.rotation.eulerAngles.z * Mathf.PI / 180);
        //Debug.Log(Time.fixedDeltaTime);
        Vector3 ballAcceleration = new Vector3(ballAccelerationRate * accelerationRateX, 0f, ballAccelerationRate * accelerationRateZ) * Time.fixedDeltaTime;
        Debug.Log(ballAcceleration);
        ballRigidBody.AddForce(ballAcceleration, ForceMode.VelocityChange);
        // ballRigidBody.linearVelocity += ballAcceleration;
        //Debug.Log(ballRigidBody.linearVelocity);
        
    }


    public void EnableMaze()
    {
        mazeTransform.DOMove(upPosition, animationSpeed);
        Invoke("SpawnBall", animationSpeed + 0.5f);

    }

    public void DisableMaze()
    {
        Destroy(ball.gameObject);
        mazeTransform.DOMove(downPosition, animationSpeed);
    }

    private void SpawnBall()
    {
        Instantiate(ball, maze.spawnLocation.position, Quaternion.identity);
    }
}
