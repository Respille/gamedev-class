using UnityEngine;

public class FlashlightEdgesV2 : MonoBehaviour
{
    [SerializeField] private Light spotLight;

    private void Update()
    {
        if (spotLight == null) return;

        Transform t = spotLight.transform;
        float halfAngle = spotLight.spotAngle * 0.5f;

        for (int i = 0; i < 8; i++)
        {
            // Rotate around the light's forward axis to get eight evenly
            // spaced directions around the cone.
            float aroundAngle = i * 45f;
            Vector3 edgeDirection =
                Quaternion.AngleAxis(aroundAngle, t.forward) * t.up;

            Vector3 rayDirection =
                Quaternion.AngleAxis(halfAngle, edgeDirection) * t.forward;

            Debug.DrawRay(
                t.position,
                rayDirection.normalized * spotLight.range,
                Color.yellow
            );
        }
    }
}