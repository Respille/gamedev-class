using UnityEngine;

public class IndividualBonusPanelController : MonoBehaviour
{
    [SerializeField] SOPlayerStats SOPlayerStats;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SOPlayerStats.TriggerRandomBonus();
            Destroy(gameObject);
        }
    }
}
