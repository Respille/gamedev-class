using UnityEngine;

public class SphereHandler : MonoBehaviour
{
    [SerializeField] private float radius = 2f;
    [SerializeField] private LayerMask layersToDetect;

    // Update is called once per frame
    void Update()
    {
        bool isHit = Physics.CheckSphere(transform.position, radius, layersToDetect);
        if (isHit)
        {
            print("Player hit by sphere");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
