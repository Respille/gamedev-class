using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private Rigidbody rb;
    private bool hasCollided = false;

    void Start()
    {    
        rb = GetComponent<Rigidbody>();
        Collider collider = GetComponent<Collider>();
        Collider parentCollider = transform.parent.gameObject.GetComponent<Collider>();
        Physics.IgnoreCollision(collider, parentCollider, true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasCollided && collision.collider.CompareTag("Projectile"))
        {
            Rigidbody projectileRb = collision.rigidbody;
            Vector3 incomingVelocity = projectileRb.linearVelocity;
            ContactPoint contact = collision.GetContact(0);

            // Launch projectile manually (otherwise it doesn't really get launched, probably because I just turned isKinematic off now)
            rb.isKinematic = false;
            rb.AddForceAtPosition(
                incomingVelocity * projectileRb.mass,
                contact.point,
                ForceMode.Impulse
            );

            hasCollided = true;
            ScoreTracker.incrementScore();
        }
    }
}
