using UnityEngine;

public class TeleportTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject playerCamera;

    [SerializeField]
    Vector3 destination;

    [SerializeField]
    Vector3 newRotationAxis;

    [SerializeField]
    float newRotationAngle;

    [SerializeField]
    Vector3 newCameraDistance;

    [SerializeField]
    Vector3 newCameraAngle; // Euler angle

    [SerializeField]
    bool shouldCameraMove;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CharacterController playerCharacterController = player.GetComponent<CharacterController>();
            MovementController playerMovementController = player.GetComponent<MovementController>();

            playerMovementController.enabled = false;
            playerCharacterController.enabled = false; // to prevent it from overwriting the new position

            player.transform.position = destination;
            playerMovementController.RotationAxis = newRotationAxis;
            playerMovementController.RotationAngle = newRotationAngle;
            playerMovementController.YVelocity = 0f;

            playerCharacterController.enabled = true;
            playerMovementController.enabled = true;

            playerCamera.transform.rotation = Quaternion.Euler(newCameraAngle);
            playerCamera.transform.position = player.transform.position + newCameraDistance;

            FollowPlayerController cameraFollowPlayerController = playerCamera.GetComponent<FollowPlayerController>();
            cameraFollowPlayerController.distanceFromPlayer = newCameraDistance;
            cameraFollowPlayerController.isMoving = shouldCameraMove;
        }
    }
}
