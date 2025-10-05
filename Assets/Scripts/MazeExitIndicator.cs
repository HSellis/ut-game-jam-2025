using UnityEngine;

public class MazeExitIndicator : MonoBehaviour
{
    public MazeHole mazeHole;
    public Color color;
    public float rotationSpeed = 50f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<MeshRenderer>().material.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        if (mazeHole == null)
        {
            Destroy(gameObject);
            return;
        }

        transform.position = mazeHole.transform.position + Vector3.up * 3;
        transform.Rotate(Vector3.left, rotationSpeed * Time.deltaTime);
    }
}
