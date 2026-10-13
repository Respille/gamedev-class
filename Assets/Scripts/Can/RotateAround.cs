using UnityEngine;

public class RotateAround : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float rotationSpeed = 45f;

    // Update is called once per frame
    void Update()
    {
        Quaternion initialRotation = transform.rotation;
        transform.RotateAround(target.position, Vector3.forward, rotationSpeed * Time.deltaTime);
        transform.rotation = initialRotation;
    }
}
