using UnityEngine;

public class VictoryZoneController : MonoBehaviour
{
    [SerializeField] SOPlayerStats SOPlayerStats;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Colliding");
            SOPlayerStats.TriggerVictory();
        }
    }
}
