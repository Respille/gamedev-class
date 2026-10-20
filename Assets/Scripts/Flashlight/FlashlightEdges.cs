using UnityEngine;

public class FlashlightEdges : MonoBehaviour
{
    [SerializeField] Light spotLight;

    void Update()
    {
        if (spotLight == null) return;

        Transform t = spotLight.transform;
        float halfAngle = spotLight.spotAngle * 0.5f;

        Vector3[] directions =
        {
            (Quaternion.AngleAxis(halfAngle, t.right)   * t.forward).normalized,
            (Quaternion.AngleAxis(-halfAngle, t.right)  * t.forward).normalized,
            (Quaternion.AngleAxis(-halfAngle, t.up)     * t.forward).normalized,
            (Quaternion.AngleAxis(halfAngle, t.up)      * t.forward).normalized
        };

        foreach (Vector3 direction in directions)
        {
            Debug.DrawRay(t.position, direction * spotLight.range, Color.yellow);
        }
    }
}