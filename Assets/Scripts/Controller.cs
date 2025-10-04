using UnityEngine;

public class Controller : MonoBehaviour
{
    public Transform mazeTransform;
    public float rotationSpeed = 10;

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
}
