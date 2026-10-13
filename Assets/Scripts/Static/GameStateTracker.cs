using System;
using UnityEngine;

public static class GameStateTracker
{
    public static event Action StartAction;
    public static event Action StartStaticModeAction;
    public static event Action StartMovingModeAction;
    public static event Action EndAction;
    public static event Action VictoryAction;
    public static event Action GameOverAction;
    public static bool IsInGame { get; private set; } = false;

    public static void StartGame()
    {
        StartAction?.Invoke();
        IsInGame = true;
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

    public static void EndGame()
    {
        EndAction?.Invoke();
        IsInGame = false;
    }

    public static void TriggerVictory()
    {
        VictoryAction?.Invoke();
        EndGame();
    }

    public static void TriggerGameOver()
    {
        GameOverAction?.Invoke();
        EndGame();
    }
}
