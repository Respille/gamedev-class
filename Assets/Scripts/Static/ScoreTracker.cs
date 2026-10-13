using System;
using UnityEngine;

public static class ScoreTracker
{
    public static event Action ChangeScoreAction;
    public static int Score { get; private set; } = 0;
    private static int scoreThreshold; // score needed to win
    public static readonly int staticScoreThreshold = 5;
    public static readonly int movingScoreThreshold = 8;

    static ScoreTracker()
    {
        GameStateTracker.StartStaticModeAction += setScoreThresholdToStatic;
        GameStateTracker.StartMovingModeAction += setScoreThresholdToMoving;
    }

    public static void incrementScore()
    {
        if (!GameStateTracker.IsInGame)
        {
            return;
        }
        Score++;
        ChangeScoreAction?.Invoke();
        if (Score == scoreThreshold)
        {
            GameStateTracker.TriggerVictory();
        }
    }

    static void setScoreThresholdToStatic()
    {
        scoreThreshold = staticScoreThreshold;
    }

    static void setScoreThresholdToMoving()
    {
        scoreThreshold = movingScoreThreshold;
    }
}
