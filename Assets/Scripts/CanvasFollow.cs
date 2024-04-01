using UnityEngine;


public class CanvasFollow : MonoBehaviour
{
    public GameObject mainCamera;
    public float lerpSpeed = 0.1f;
    public float predefinedDistance = 1;
    public bool moveWithPlayer;
    public bool rotateWithPlayer;
    public bool scaleFromPlayer;
    [Header("Scaling")]
    public float defaultScale = 0.001f;
    public float minDistanceThreshold = 0.3f;
    public float maxDistance = 5.0f;
    public float distance;

    void Update()
    {
        // Ensure we have references to the Canvas and Camera
        if (mainCamera == null)
        {
            Debug.LogError("Main Camera not assigned in the inspector!");
            return;
        }
        if (moveWithPlayer)
        {
            // use main camera position and forward vector to calculate canvas position
            Vector3 targetPosition = mainCamera.transform.position + mainCamera.transform.forward * predefinedDistance;
            transform.position = Vector3.Lerp(transform.position, targetPosition, lerpSpeed);
        }
        if (rotateWithPlayer)
        {
            // look at main camera and flip canvas forward vector
            transform.LookAt(new Vector3(mainCamera.transform.position.x, transform.position.y, mainCamera.transform.position.z));
            transform.forward *= -1;
        }
        if (scaleFromPlayer)
        {
            // Calculate distance
            distance = Vector3.Distance(transform.position, mainCamera.transform.position);

            // Check if we are under or over threshold and use preset
            if (distance < minDistanceThreshold)
            {
                distance = minDistanceThreshold;
            }
            if (distance > maxDistance)
            {
                distance = maxDistance;
            }
            // Apply the scale
            float scale = distance * defaultScale;
            transform.localScale = new Vector3(scale, scale, scale);
        }
    }
}
