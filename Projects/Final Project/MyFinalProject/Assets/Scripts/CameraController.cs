using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform target; // Player

    [Header("Camera Settings")]
    public float smoothSpeed = 0.1f;
    public Vector3 offset;    // Optional offset to position camera

    [Header("Level Boundaries")]
    public Vector2 minBounds; // Limit inferior (x,y)
    public Vector2 maxBounds; // Limit superior (x,y)

    private Vector3 velocity = Vector3.zero;

    void Start()
    {
       
    }

    private void LateUpdate()
    {
        if (target == null) 
           return;

        // Desired position (target position + offset)
        Vector3 desiredPosition = target.position + offset;

        // Smooth camera movement
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Clamp camera within bounds
        smoothedPosition.x = Mathf.Clamp(smoothedPosition.x, minBounds.x, maxBounds.x);
        smoothedPosition.y = Mathf.Clamp(smoothedPosition.y, minBounds.y, maxBounds.y);

        // Apply position
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
    }

}