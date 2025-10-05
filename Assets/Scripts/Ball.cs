using UnityEngine;

public class Ball : MonoBehaviour
{
    private AudioSource audioSource;
    private Rigidbody rb;


    private float maxVolume;
    public float maxVelocityValue = 1.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();

        maxVolume = audioSource.volume;
        Debug.Log(maxVolume);
    }

    // Update is called once per frame
    void Update()
    {
        float velocityMagnitude = rb.linearVelocity.magnitude;
        float velocityPercentage = Mathf.Clamp01(velocityMagnitude / maxVelocityValue);
        Debug.Log(velocityPercentage);
        audioSource.volume = velocityPercentage;
    }
}
