using UnityEngine;
using UnityEngine.UIElements;

public class FollowPlayerController : MonoBehaviour
{
    [SerializeField] Transform playerTransform;

    // LateUpdate so camera follows player's updated position
    void LateUpdate()
    {
        transform.position = playerTransform.position;
        transform.rotation = playerTransform.rotation;
    }
}