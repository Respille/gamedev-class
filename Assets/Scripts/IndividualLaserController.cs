using UnityEngine;

public class IndividualLaserController : MonoBehaviour
{
    [SerializeField] SOPlayerStats SOPlayerStats;
    [SerializeField] float laserSpeed = 5f;
    [SerializeField] int damage = 10;

    void Update()
    {
        Vector3 position = transform.position;
        position.z -= laserSpeed * Time.deltaTime;
        transform.position = position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SOPlayerStats.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
