using UnityEngine;

public class ElevatorMovement : MonoBehaviour
{
    public float verticalAmplitude = 2.0f;   // Maximum vertical distance of movement
    public float verticalSpeed = 1.0f;       // Speed of vertical movement

    public float horizontalAmplitude = 2.0f; // Maximum horizontal distance of movement
    public float horizontalSpeed = 1.0f;     // Speed of horizontal movement

    private Vector3 initialPosition;
    private float timeElapsed = 0.0f;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        // Vertical movement
        float newY = initialPosition.y + verticalAmplitude * Mathf.Sin(verticalSpeed * timeElapsed);

        // Horizontal movement
        float newX = initialPosition.x + horizontalAmplitude * Mathf.Cos(horizontalSpeed * timeElapsed);

        transform.position = new Vector3(newX, newY, transform.position.z);
    }
}
