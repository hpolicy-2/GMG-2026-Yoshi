using UnityEngine;

public class CloudMover : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 2f;

    [Header("Looping")]
    public float leftBound = -15f;
    public float rightBound = 15f;

    void Update()
    {
        // Move to the right
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;

        // Loop back to the left when it goes off-screen
        if (transform.position.x > rightBound)
        {
            transform.position = new Vector3(
                leftBound,
                transform.position.y,
                transform.position.z
            );
        }
    }
}