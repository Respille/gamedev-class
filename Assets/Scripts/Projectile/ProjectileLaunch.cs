using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float launchForce = 10f;
    Camera playerCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerCamera = Camera.main;

        // Make sure projectile does not collide with player
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        CharacterController playerController = player.GetComponent<CharacterController>();
        Collider playerCollider = player.GetComponent<Collider>();
        Collider projectileCollider = GetComponent<Collider>();
        if (playerCollider != null && playerController != null && projectileCollider != null)
        {
            Physics.IgnoreCollision(projectileCollider, playerController, true);
            Physics.IgnoreCollision(projectileCollider, playerCollider, true);
        }

        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        Vector3 launchDirection = playerCamera.transform.forward.normalized;
        Debug.DrawRay(rb.position, launchDirection * 3f, Color.red, 2f);
        Debug.Log($"Launch direction: {launchDirection}, camera rotation: {playerCamera.transform.eulerAngles}");

        rb.AddForce(launchDirection * launchForce, ForceMode.Impulse);
    }
}
