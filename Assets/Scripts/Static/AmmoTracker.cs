using System;
using UnityEngine;

public static class AmmoTracker
{
    public static event Action AmmoChangeAction;
    public static readonly int initialAmmo = 20;
    public static int Ammo { get; private set; } = initialAmmo;
    public static bool IsInGame { get; private set; } = false;

    static AmmoTracker()
    {
        GameStateTracker.StartAction += SetInGameToTrue;
    }

    public static bool AllowedToShoot()
    {
        if (!IsInGame)
        {
            return true;
        }
        return Ammo > 0;
    }

    public static void DecrementAmmo()
    {
        if (!IsInGame) // do not decrement ammo in lobby
        {
            return;
        }
        Ammo--;
        AmmoChangeAction?.Invoke();
    }

    public static void SetInGameToTrue()
    {
        IsInGame = true;
    }
}
