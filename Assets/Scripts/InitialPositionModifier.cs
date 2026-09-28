using UnityEngine;

public class InitialPositionModifier : MonoBehaviour
{
    [SerializeField]
    int numberOfSteps; // can be negative to go in the opposite direction

    [SerializeField]
    Vector3 distancePerStep;

    [SerializeField]
    Vector3 rotationAxis;

    [SerializeField]
    float rotationAnglePerStep;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position += distancePerStep * numberOfSteps;
        transform.Rotate(rotationAxis, rotationAnglePerStep * numberOfSteps);
    }
}
