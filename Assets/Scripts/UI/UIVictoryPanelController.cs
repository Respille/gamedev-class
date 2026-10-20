using TMPro;
using UnityEngine;

public class UIVictoryPanelController : MonoBehaviour
{
    [SerializeField] GameObject victoryPanel;

    void OnEnable()
    {
        GameStateTracker.VictoryAction += ShowVictoryPanel;
    }

    void OnDisable()
    {
        GameStateTracker.VictoryAction -= ShowVictoryPanel;
    }

    void ShowVictoryPanel()
    {
        victoryPanel.SetActive(true);
    }
}
