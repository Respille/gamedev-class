using System.Collections;
using UnityEngine;

public class CountdownManager : MonoBehaviour
{
    Coroutine countdownCoroutine;

    void OnEnable()
    {
        GameStateTracker.StartAction += StartCountdown;
        GameStateTracker.EndAction += StopCountdown;
    }

    void OnDisable()
    {
        GameStateTracker.StartAction -= StartCountdown;
        GameStateTracker.EndAction -= StopCountdown;
        StopCountdown();
    }

    void StartCountdown()
    {
        countdownCoroutine = StartCoroutine(CountdownRoutine());
    }

    void StopCountdown()
    {
        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
        }
        countdownCoroutine = null;
    }

    IEnumerator CountdownRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            CountdownTracker.DecrementCountdown();
        }
    }
}
