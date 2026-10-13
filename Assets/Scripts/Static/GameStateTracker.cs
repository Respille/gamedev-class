using System;
using UnityEngine;

public static class GameStateTracker
{
    public static event Action StartAction;
    public static event Action StartStaticModeAction;
    public static event Action StartMovingModeAction;
    public static event Action VictoryAction;
    public static event Action GameOverAction;

    public static void StartGame()
    {
        StartAction?.Invoke();
    }

    public static void StartStaticTargetsMode()
    {
        StartStaticModeAction?.Invoke();
        StartGame();
    }

    public static void StartMovingTargetsMode()
    {
        StartMovingModeAction?.Invoke();
        StartGame();
    }

    public static void TriggerVictory()
    {
        VictoryAction?.Invoke();
    }

    public static void TriggerGameOver()
    {
        GameOverAction?.Invoke();
    }
}
