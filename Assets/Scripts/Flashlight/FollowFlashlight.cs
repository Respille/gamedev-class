using UnityEngine;

public class FollowFlashlight : MonoBehaviour
{
    [SerializeField] private Transform followTarget;
    [SerializeField] private Vector3 positionOffset;

    private void LateUpdate()
    {
        if (followTarget == null) return;

        transform.position = followTarget.TransformPoint(positionOffset);
        transform.rotation = followTarget.rotation;
    }
}