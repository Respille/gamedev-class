using UnityEngine;
using UnityEngine.InputSystem;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] GameObject projectilePrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector3 playerPos = playerTransform.position;
            Instantiate(projectilePrefab, playerPos, Quaternion.identity);
        }
    }
}
