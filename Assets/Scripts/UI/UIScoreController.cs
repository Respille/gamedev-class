using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class UIScoreController : MonoBehaviour
{
    TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText.text = "";
    }

    void OnEnable()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        ScoreTracker.ChangeScoreAction += ChangeText;
        GameStateTracker.StartAction += ChangeText;
    }

    void OnDisable()
    {
        ScoreTracker.ChangeScoreAction -= ChangeText;
        GameStateTracker.StartAction -= ChangeText;
    }

    void ChangeText()
    {
        scoreText.text = $"Score: {ScoreTracker.Score}";
    }
}
