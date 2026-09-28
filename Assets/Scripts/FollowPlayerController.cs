using UnityEngine;

public class FollowPlayerController : MonoBehaviour
{
    Vector3 distanceFromPlayer;

    [SerializeField]
    Transform playerTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        distanceFromPlayer = transform.position - playerTransform.position;
    }

    // LateUpdate so camera follows player's updated position
    void LateUpdate()
    {
        transform.position = playerTransform.position + distanceFromPlayer;
    }
}
