using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class UIResultController : MonoBehaviour
{
    TextMeshProUGUI resultText;

    void Start()
    {
        resultText.text = "";
    }

    void OnEnable()
    {
        resultText = GetComponent<TextMeshProUGUI>();
        GameStateTracker.VictoryAction += SetTextToWin;
        GameStateTracker.GameOverAction += SetTextToLose;
        AmmoTracker.OutOfAmmoAction += SetTextToOutOfAmmo;
    }

    void OnDisable()
    {
        GameStateTracker.VictoryAction -= SetTextToWin;
        GameStateTracker.GameOverAction -= SetTextToLose;
        AmmoTracker.OutOfAmmoAction -= SetTextToOutOfAmmo;
    }

    void SetTextToWin()
    {
        resultText.text = "YOU WIN!";
        resultText.color = Color.yellow;
    }

    void SetTextToLose()
    {
        resultText.text = "GAME OVER!";
        resultText.color = Color.red;
    }

    void SetTextToOutOfAmmo()
    {
        resultText.text = "Out of ammo!";
        resultText.color = Color.red;
    }
}
