using System;
using UnityEngine;

public static class ScoreTracker
{
    public static event Action ChangeScoreAction;
    public static int Score { get; private set; } = 0;


    public static void incrementScore()
    {
        Score++;
        ChangeScoreAction?.Invoke();
    }
}
