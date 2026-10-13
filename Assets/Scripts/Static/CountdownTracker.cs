using System;
using UnityEngine;

public static class CountdownTracker
{
    public static event Action CountdownChangeAction;
    public static readonly int initialCountdown = 99;
    public static int CurrentCountdown { get; private set; } = initialCountdown;

    public static void InitializeCountdown()
    {
        CurrentCountdown = initialCountdown;
        CountdownChangeAction?.Invoke();
    }

    public static void DecrementCountdown()
    {
        CurrentCountdown--;
        CountdownChangeAction?.Invoke();
        if (CurrentCountdown == 0)
        {
            GameStateTracker.TriggerGameOver();
        }
    }
}
