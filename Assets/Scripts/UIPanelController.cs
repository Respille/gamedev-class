using System.Collections;
using UnityEngine;

public class UIPanelController : MonoBehaviour
{
    [SerializeField] SOPlayerStats SOPlayerStats;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject victoryPanel;

    void OnEnable()
    {
        SOPlayerStats.GameOverAction += ShowGameOverScreen;
        SOPlayerStats.VictoryAction += ShowVictoryScreen;
    }

    void OnDisable()
    {
        SOPlayerStats.GameOverAction -= ShowGameOverScreen;
        SOPlayerStats.VictoryAction -= ShowVictoryScreen;
    }

    public void ShowGameOverScreen()
    {
        StartCoroutine(ShowGameOverScreenCoroutine());
    }

    IEnumerator ShowGameOverScreenCoroutine()
    {
        // activates game over panel for a few seconds and freezes scene while it is shown
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(3f);

        gameOverPanel.SetActive(false);
        Time.timeScale = 1;
        yield break;
    }

    public void ShowVictoryScreen()
    {
        victoryPanel.SetActive(true);
    }
}
