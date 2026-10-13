using UnityEngine;

public class StaticCollisionDetection : MonoBehaviour
{
    private Rigidbody rb;
    private bool hasCollided = false;

    void Start()
    {    
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasCollided && collision.collider.CompareTag("Projectile"))
        {
            hasCollided = true;
            ScoreTracker.incrementScore();
        }
    }
}
