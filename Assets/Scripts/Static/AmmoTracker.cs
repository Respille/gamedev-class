using System;

public static class AmmoTracker
{
    public static event Action AmmoChangeAction;
    public static event Action OutOfAmmoAction;
    public static readonly int initialAmmo = 20;
    public static int Ammo { get; private set; } = initialAmmo;

    public static bool AllowedToShoot()
    {
        if (!GameStateTracker.IsInGame)
        {
            return true;
        }
        return Ammo > 0;
    }

    public static void DecrementAmmo()
    {
        if (!GameStateTracker.IsInGame) // do not decrement ammo in lobby
        {
            return;
        }
        Ammo--;
        AmmoChangeAction?.Invoke();
        if (Ammo == 0)
        {
            OutOfAmmoAction?.Invoke();
        }
    }
}
