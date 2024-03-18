using UnityEngine;


public class CanvasFollow : MonoBehaviour
{
    public GameObject mainCamera;

    public float lerpSpeed = 0.1f;

    public float distanceFromPlayer = 1;

    public bool moveWithPlayer;

    public bool rotateWithPlayer;

    void Update()
    {
        // Ensure we have references to the Canvas and Camera
        if (this.transform == null || mainCamera == null)
        {
            Debug.LogError("Canvas or Main Camera not assigned in the inspector!");
            return;
        }

        if (moveWithPlayer)
        {
            Vector3 targetPosition = mainCamera.transform.position + mainCamera.transform.forward * distanceFromPlayer;
            transform.position = Vector3.Lerp(transform.position, targetPosition, lerpSpeed);
        }

        if (rotateWithPlayer)
        {
            transform.LookAt(new Vector3(mainCamera.transform.position.x, transform.position.y, mainCamera.transform.position.z));
            transform.forward *= -1;
        }
    }
}
