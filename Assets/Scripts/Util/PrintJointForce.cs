using UnityEngine;

public class PrintJointForce : MonoBehaviour
{
    private Joint joint;

    void Start()
    {
        joint = GetComponent<Joint>();
    }

    void Update()
    {
        Vector3 force = joint.currentForce;
        float magnitude = force.magnitude;
        if (magnitude > 10)
        {
            Debug.Log("Current Joint Force: " + force + " | Magnitude: " + force.magnitude);
        }
        

        // For rotational torque (twisting force)
        //Vector3 torque = joint.currentTorque;
        //Debug.Log("Current Joint Torque: " + torque);
    }
}