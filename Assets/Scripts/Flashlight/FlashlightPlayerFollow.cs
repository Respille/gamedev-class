using UnityEngine;

public class FlashlightPlayerFollow: MonoBehaviour
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