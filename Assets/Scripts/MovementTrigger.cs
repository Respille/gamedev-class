using UnityEngine;

public class MovementTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject obj;

    [SerializeField]
    Vector3 distance;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            obj.transform.position += distance * 2;
        }
    }
}
