using System;
using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "SOPlayerStats", menuName = "Custom/Scriptable Objects/Player Stats")]
public class SOPlayerStats : ScriptableObject
{
    public int initialHealth = 100;
    public float initialBaseMoveSpeed = 5f;
    public event Action HealthChangedAction;
    public event Action GameOverAction;

    private int _health;
    public int Health
    {
        get => _health;
        private set
        {
            _health = value;
            HealthChangedAction?.Invoke(); // invoke action whenever health is changed
        }
    }
    public float BaseMoveSpeed { get; private set; }

    public void ResetValues()
    {
        Health = initialHealth;
        BaseMoveSpeed = initialBaseMoveSpeed;
    }

    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            Health -= damage;
            if (Health <= 0)
            {
                TriggerGameOver();
                ResetValues();
            }
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(damage), "Cannot take negative or zero damage");
        }
    }

    public void Heal(int healing)
    {
        if (healing > 0)
        {
            Health += healing;
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(healing), "Cannot have negative or zero healing");
        }
    }

    public void TriggerGameOver()
    {
        GameOverAction?.Invoke();
        ResetValues();
    }

    public void TriggerRandomBonus()
    {

    }
}
