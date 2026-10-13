using System;
using UnityEngine;

public static class GameStateTracker
{
    public static event Action StartAction;

    public static void StartGame()
    {
        StartAction?.Invoke();
    }
}
