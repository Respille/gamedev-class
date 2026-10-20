using UnityEngine;

public class VictoryTrigger : MonoBehaviour
{
    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameStateTracker.TriggerVictory();
        }
    }
}
