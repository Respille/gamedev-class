using TMPro;
using UnityEngine;

public class UIHealthController : MonoBehaviour
{
    [SerializeField] SOPlayerStats SOPlayerStats;
    [SerializeField] TextMeshProUGUI healthText;

    void OnEnable()
    {
        SOPlayerStats.HealthChangedAction += updateHealthText;
    }

    void OnDisable()
    {
        SOPlayerStats.HealthChangedAction -= updateHealthText;
    }

    public void updateHealthText()
    {
        healthText.text = "Health: " + SOPlayerStats.Health.ToString();
    }
}
