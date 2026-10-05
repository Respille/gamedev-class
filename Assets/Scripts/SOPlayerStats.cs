using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SOPlayerStats", menuName = "Custom/Scriptable Objects/Player Stats")]
public class SOPlayerStats : ScriptableObject
{
    public int initialHealth = 100;
    public float initialBaseMoveSpeed = 5f;
    public event Action HealthChangedAction;

    public int Health { get; private set; }
    public float BaseMoveSpeed { get; private set; }

    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            Health -= damage;
            HealthChangedAction?.Invoke();
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(damage), "Cannot take negative or zero damage");
        }
    }

    public void ResetValues()
    {
        Health = initialHealth;
        BaseMoveSpeed = initialBaseMoveSpeed;
    }
}
