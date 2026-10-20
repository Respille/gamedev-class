using UnityEngine;

[ExecuteAlways] // lets you see laser in the editor
[RequireComponent(typeof(LineRenderer))]
public class LaserHandler : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField] private float maxDistance = 200f;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void FixedUpdate()
    {
        ShootLaser();
    }

    void ShootLaser()
    {
        lineRenderer.SetPosition(0, transform.position); // start position of laser
        Vector3 endPosition = transform.position + (transform.forward * maxDistance);

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, maxDistance))
        {
            endPosition = hit.point; // if laser hits something, make that the end position
            if (hit.collider.CompareTag("Player"))
            {
                HealthTracker.DamagePlayer(1);
            }
        }

        lineRenderer.SetPosition(1, endPosition);
    }
}