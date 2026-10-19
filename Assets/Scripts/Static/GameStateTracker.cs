using System;
using UnityEngine;

public static class GameStateTracker
{
    public static event Action StartAction;
    public static event Action EndAction;
    public static event Action VictoryAction;
    public static event Action GameOverAction;
    
    public static void StartGame()
    {
        StartAction?.Invoke();
    }

    public static void TriggerVictory()
    {
        VictoryAction?.Invoke();
        EndAction?.Invoke();
    }

    public static void TriggerGameOver()
    {
        GameOverAction?.Invoke();
        EndAction?.Invoke();
    }
}
