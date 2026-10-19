using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class UIHealthController : MonoBehaviour
{
    TextMeshProUGUI healthText;

    void OnEnable()
    {
        healthText = GetComponent<TextMeshProUGUI>();
        HealthTracker.HealthChangeAction += ChangeText;
        GameStateTracker.StartAction += ChangeText;
    }

    void OnDisable()
    {
        HealthTracker.HealthChangeAction += ChangeText;
        GameStateTracker.StartAction -= ChangeText;
    }

    void ChangeText()
    {
        healthText.text = $"Health: {Mathf.Ceil(HealthTracker.CurrentHealth)}";
    }
}
