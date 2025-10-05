using UnityEngine;

public class RizzOrb : MonoBehaviour
{
    private NarrativeController narrativeController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        narrativeController = NarrativeController.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null) {
            narrativeController.AddRizz(1);
            Destroy(gameObject);
        }
    }
}
