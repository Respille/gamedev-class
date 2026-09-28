using UnityEngine;

public class JumpBlockTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("A plyer has entered!");
        }
    }
}

