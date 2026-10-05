using UnityEngine;

public class IndividualLaserController : MonoBehaviour
{
    [SerializeField] SOPlayerStats SOPlayerStats;
    [SerializeField] SOLaserStats SOLaserStats;

    void Update()
    {
        Vector3 position = transform.position;
        position.z -= SOLaserStats.LaserSpeed * Time.deltaTime;
        transform.position = position;

        if (position.z < -101)
        {
            Destroy(gameObject); // destroy laser once it has gone out of bounds
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SOPlayerStats.TakeDamage(SOLaserStats.Damage);
            Destroy(gameObject);
        }
    }
}
