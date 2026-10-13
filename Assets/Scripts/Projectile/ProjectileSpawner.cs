using UnityEngine;
using UnityEngine.InputSystem;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] GameObject projectilePrefab;

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (!AmmoTracker.AllowedToShoot())
            {
                return;
            }
            AmmoTracker.DecrementAmmo();
            Vector3 playerPos = playerTransform.position;
            Instantiate(projectilePrefab, playerPos, Quaternion.identity);
        }
    }
}
