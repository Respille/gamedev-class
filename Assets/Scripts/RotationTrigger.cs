using UnityEngine;

public class RotationTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject obj;

    [SerializeField]
    float angle;

    [SerializeField]
    Vector3 axis;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            obj.transform.Rotate(axis, angle);
        }
    }
}
