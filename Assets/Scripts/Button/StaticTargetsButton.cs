using UnityEngine;

public class StaticButton : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Projectile"))
        {
            Destroy(collision.gameObject);
            GameStateTracker.StartStaticTargetsMode();
        }
    }
}
