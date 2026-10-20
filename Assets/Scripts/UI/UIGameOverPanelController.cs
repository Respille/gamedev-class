using TMPro;
using UnityEngine;

public class UIGameOverPanelController : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;

    void OnEnable()
    {
        GameStateTracker.GameOverAction += ShowGameOverPanel;
    }

    void OnDisable()
    {
        GameStateTracker.GameOverAction -= ShowGameOverPanel;
    }

    void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }
}
