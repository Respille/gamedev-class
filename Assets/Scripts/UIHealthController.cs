using TMPro;
using UnityEngine;

public class UIHealthController : MonoBehaviour
{
    [SerializeField] SOPlayerStats SOPlayerStats;
    [SerializeField] TextMeshProUGUI healthText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        SOPlayerStats.HealthChangedAction += updateHealthText;
    }

    // Update is called once per frame
    void OnDisable()
    {
        SOPlayerStats.HealthChangedAction -= updateHealthText;
    }

    public void updateHealthText()
    {
        healthText.text = "Health: " + SOPlayerStats.Health.ToString();
    }
}
