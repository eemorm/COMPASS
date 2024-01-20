using UnityEngine;

public class ItemBob : MonoBehaviour
{
    public float amplitude = 0.5f;   // Set the amplitude of the sine wave
    public float frequency = 1f;   // Set the frequency of the sine wave

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Calculate the vertical offset using a sine wave
        float yOffset = amplitude * Mathf.Sin(Time.time * frequency);

        // Update the object's position
        transform.position = startPos + new Vector3(0f, yOffset, 0f);
    }
}