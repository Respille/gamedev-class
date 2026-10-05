using UnityEngine;
using UnityEngine.UIElements;

public class FollowPlayerController : MonoBehaviour
{
    float distanceFromPlayer; // only on the z-axis

    [SerializeField] Transform playerTransform;
    [SerializeField] float smoothingFactor = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        distanceFromPlayer = transform.position.z - playerTransform.position.z;
    }

    // LateUpdate so camera follows player's updated position
    void LateUpdate()
    {
        Vector3 finalPos = transform.position;
        finalPos.z = playerTransform.position.z + distanceFromPlayer;

        // Lerp makes the camera movement smoother
        Vector3 newPos = Vector3.Lerp(transform.position, finalPos, Time.deltaTime * smoothingFactor);
        transform.position = newPos;
    }
}