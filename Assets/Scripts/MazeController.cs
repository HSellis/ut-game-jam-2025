using DG.Tweening;
using UnityEngine;

public class MazeController : MonoBehaviour
{
    public Transform mazeTransform;
    public float rotationSpeed = 10;

    public float animationSpeed = 2;
    public Vector3 upPosition;
    public Vector3 downPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //mazeBody = mazeTransform.GetComponent<Rigidbody>();
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


    public void MoveUp()
    {
        mazeTransform.DOMove(upPosition, animationSpeed);
    }

    public void MoveDown()
    {
        mazeTransform.DOMove(downPosition, animationSpeed);
    }
}
