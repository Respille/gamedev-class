using System.Collections;
using UnityEngine;

public class OneTimeMovementGeneric : MonoBehaviour
{
    [SerializeField] float duration = 5f;
    Transform transformToMove;
    Vector3 initialPosition;
    Vector3 finalPosition;
    bool alreadyMoved = false; // makes sure you can only move it once

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transformToMove = transform.parent;
        initialPosition = transformToMove.position;
        finalPosition = transform.Find("FinalPosition").position;
    }

    protected void Move()
    {
        if (alreadyMoved) return;
        alreadyMoved = true;
        StartCoroutine(MoveEnumerator());
    }

    private IEnumerator MoveEnumerator()
    {
        print("Move called");
        float elapsed = 0f;

        while (elapsed < duration)
        {
            print($"Moving: {elapsed}");
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration); // makes sure it's not more than 1
            transformToMove.position = Vector3.Lerp(initialPosition, finalPosition, t);
            yield return null; // wait until next frame
        }

        transform.position = finalPosition;
    }
}
