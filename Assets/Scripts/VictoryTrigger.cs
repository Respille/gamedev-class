using Unity.VisualScripting;
using UnityEngine;

public class VictoryTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject victoryMessage;

    [SerializeField]
    GameObject invisibleBarrier; // to prevent the player from falling off after winning

    void Start()
    {
        victoryMessage.SetActive(false);
        invisibleBarrier.GetComponent<MeshCollider>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            victoryMessage.SetActive(true);
            invisibleBarrier.GetComponent<MeshCollider>().enabled = true;
            gameObject.SetActive(false); // deactivates the collider so the victory doesn't trigger more than once
        }
    }
}
