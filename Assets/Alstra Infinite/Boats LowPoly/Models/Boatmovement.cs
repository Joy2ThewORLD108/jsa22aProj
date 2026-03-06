using UnityEngine;

public class BoatFloat : MonoBehaviour
{
    [Header("Bobbing Settings")]
    public float verticalAmplitude = 0.2f; // How high it bobs
    public float verticalFrequency = 1f;  // How fast it bobs

    [Header("Rocking Settings")]
    public float rockingAmplitude = 2.0f; // How far it tilts left/right
    public float rockingFrequency = 0.5f; // How fast it tilts

    private Vector3 startPosition;
    private Quaternion startRotation;

    void Start()
    {
        // Save the original position and rotation
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    void Update()
    {
        // 1. Vertical Bobbing (Up and Down)
        float newY = startPosition.y + Mathf.Sin(Time.time * verticalFrequency) * verticalAmplitude;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);

        // 2. Side-to-Side Rocking (Rotation on Z axis)
        float tiltZ = Mathf.Sin(Time.time * rockingFrequency) * rockingAmplitude;

        // Apply the tilt while keeping the original orientation
        transform.rotation = startRotation * Quaternion.Euler(0, 0, tiltZ);
    }
}