using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class UICountdownController : MonoBehaviour
{
    TextMeshProUGUI countdownText;

    void Start()
    {
        countdownText.text = "";
    }

    void OnEnable()
    {
        countdownText = GetComponent<TextMeshProUGUI>();
        CountdownTracker.CountdownChangeAction += ChangeText;
        GameStateTracker.StartAction += ChangeText;
    }

    void OnDisable()
    {
        CountdownTracker.CountdownChangeAction -= ChangeText;
        GameStateTracker.StartAction -= ChangeText;
    }

    void ChangeText()
    {
        countdownText.text = $"{CountdownTracker.CurrentCountdown}";
    }
}
