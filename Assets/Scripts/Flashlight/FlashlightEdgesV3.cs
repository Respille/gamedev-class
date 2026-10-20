using UnityEngine;

public class FlashlightEdgesV3 : MonoBehaviour
{
    [SerializeField] private Light spotLight;
    [SerializeField] private float outerRingAngleCoefficient = 0.5f; // should be 0.5 at most
    [SerializeField] private int numberOfRings = 2;
    [SerializeField] private int raysPerRing = 8;

    void Update()
    {
        if (spotLight == null) return;

        Transform t = spotLight.transform;

        // the idea is to draw rings of rays inside the spot light
        for (int i = 0; i < numberOfRings; i++)
        {
            float angleCoefficient = outerRingAngleCoefficient * (numberOfRings - i) / numberOfRings;
            float angle = spotLight.spotAngle * angleCoefficient;

            for (int j = 0; j < raysPerRing; j++)
            {
                float aroundAngle = (float) j / raysPerRing * 360;
                Vector3 edgeDirection = Quaternion.AngleAxis(aroundAngle, t.forward) * t.up;
                Vector3 rayDirection = Quaternion.AngleAxis(angle, edgeDirection) * t.forward;
                Debug.DrawRay(t.position, rayDirection.normalized * spotLight.range, Color.yellow);
            }

            // one more ray for the center of the spotlight
            Debug.DrawRay(t.position, t.forward * spotLight.range, Color.cyan);
        }
        
    }
}