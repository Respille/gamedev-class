using UnityEngine;

public class FollowPlayerController : MonoBehaviour
{
    public Vector3 distanceFromPlayer;
    public bool isMoving = true;

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
        if (isMoving)
        {
            transform.position = playerTransform.position + distanceFromPlayer;
        }
    }
}
