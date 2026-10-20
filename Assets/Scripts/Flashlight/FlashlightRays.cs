using UnityEngine;

[RequireComponent(typeof(Light))]
public class FlashlightRays : MonoBehaviour
{
    private Light spotLight;
    [SerializeField] private float outerRingAngleCoefficient = 0.5f; // should be 0.5 at most
    [SerializeField] private int numberOfRings = 2;
    [SerializeField] private int raysPerRing = 8;
    [SerializeField] private float revealRange = 20f; // range where the flashlight can reveal invisible objects

    void Start()
    {
        spotLight = GetComponent<Light>();
    }
    void Update()
    {
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
                RaycastAndHandleHit(t.position, rayDirection, spotLight.range);
            }

            // one more ray for the center of the spotlight
            Debug.DrawRay(t.position, t.forward * spotLight.range, Color.cyan);
            RaycastAndHandleHit(t.position, t.forward, spotLight.range);
        }
    }

    private void RaycastAndHandleHit(Vector3 origin, Vector3 direction, float maxDistance)
    {
        if (Physics.Raycast(origin, direction, out RaycastHit hit, maxDistance))
        {
            if (hit.collider.CompareTag("HiddenUnlessLit"))
            {
                GameObject obj = hit.collider.gameObject;
                if (obj.TryGetComponent<InvisibleWhenUnlit>(out var inv))
                {
                    float distance = Vector3.Distance(obj.transform.position, transform.position);
                    if (distance <= revealRange)
                    {
                        inv.isLit = true;
                    }
                }
            }
        }
    }
}