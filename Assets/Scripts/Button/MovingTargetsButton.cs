using UnityEngine;

public class MovingTargetsButton : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Projectile"))
        {
            Destroy(collision.gameObject);
            GameStateTracker.StartMovingTargetsMode();
        }
    }
}
