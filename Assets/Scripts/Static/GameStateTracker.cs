using System;
using UnityEngine;

public static class GameStateTracker
{
    public static event Action StartAction;
    public static event Action StartStaticModeAction;
    public static event Action StartMovingModeAction;

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
}
