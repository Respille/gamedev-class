using UnityEngine;

public class IndividualLaserController : MonoBehaviour
{
    [SerializeField] SOPlayerStats SOPlayerStats;
    [SerializeField] int damage = 10;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SOPlayerStats.TakeDamage(damage);
        }
    }
}
