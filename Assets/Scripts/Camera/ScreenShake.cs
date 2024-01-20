using System.Collections;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    // Intensity of the screen shake
    public float shakeIntensity = 0.1f;

    // Duration of the screen shake
    public float shakeDuration = 0.5f;

    // Coroutine for handling the screen shake
    private Coroutine shakeCoroutine;

    // Initial position of the camera
    private Vector3 originalPosition;

    void Start()
    {
        // Save the original position of the camera
        originalPosition = transform.position;
    }

    // Function to trigger the screen shake
    public void TriggerShake()
    {
        // If a screen shake is already in progress, stop it
        if (shakeCoroutine != null)
        {
            StopCoroutine(shakeCoroutine);
        }

        // Start a new screen shake
        shakeCoroutine = StartCoroutine(Shake());
    }

    // Coroutine for the screen shake effect
    private IEnumerator Shake()
    {
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            // Generate a random offset for the camera position
            Vector3 offset = Random.insideUnitSphere * shakeIntensity;

            // Apply the offset to the camera position
            transform.position = originalPosition + offset;

            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // Reset the camera position after the shake is complete
        transform.position = originalPosition;

        // Set the coroutine reference to null
        shakeCoroutine = null;
    }
}
