using Unity.VisualScripting;
using UnityEngine;

public class ContinuousMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    Transform transformToMove;
    Vector3 initialPosition;
    Vector3 finalPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transformToMove = transform.parent;
        initialPosition = transformToMove.position;
        finalPosition = transform.Find("FinalPosition").position;
    }

    // Update is called once per frame
    void Update()
    {
        // sin oscillates smoothly between two points
        // the +1 and /2 is to make the range from 0 to 1 instead of -1 to 1 like sin usually is
        float t = (Mathf.Sin(Time.time * speed) + 1f) / 2f;
        transformToMove.position = Vector3.Lerp(initialPosition, finalPosition, t);
    }
}
