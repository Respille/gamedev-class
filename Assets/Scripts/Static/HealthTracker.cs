using System;
using System.Collections;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public static class HealthTracker
{
    public static event Action HealthChangeAction;
    public static readonly float initialHealth = 100f;
    public static float CurrentHealth { get; private set; } = initialHealth;

    public static void DamagePlayer(float amount)
    {
        CurrentHealth -= amount;
        HealthChangeAction?.Invoke();
        if (CurrentHealth <= 0)
        {
            GameStateTracker.TriggerGameOver();
        }
    }

}
