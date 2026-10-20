using System;
using System.Collections;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public static class HealthTracker
{
    public static event Action HealthChangeAction;
    public static readonly int initialHealth = 300;
    public static int CurrentHealth { get; private set; } = initialHealth;

    public static void DamagePlayer(int amount)
    {
        CurrentHealth -= amount;
        HealthChangeAction?.Invoke();
        if (CurrentHealth <= 0)
        {
            GameStateTracker.TriggerGameOver();
        }
    }

}
