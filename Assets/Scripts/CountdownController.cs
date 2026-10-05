using System.Collections;
using TMPro;
using UnityEngine;

public class CountdownController : MonoBehaviour
{
    [SerializeField] int initialCountdown = 99;
    [SerializeField] TextMeshProUGUI countdownText;

    int countdown;
    Coroutine countdownCoroutine; // in case we want to stop the coroutine later

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        countdown = initialCountdown;
        countdownText.text = countdown.ToString();
        countdownCoroutine = StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            countdown--;
            countdownText.text = countdown.ToString();
        }
    }
}
