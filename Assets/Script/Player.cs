using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Range(1,1000)]
    [SerializeField] private int Health;

    private int _minHealth = 0;
    private int _maxHealth = 1000;

    public void TakeDamage(int damage)
    {
        int value = CheckValue(damage);
        Health -= value;

        CheckHealth();
    }

    public void TakeHeal(int damage)
    {
        int value = CheckValue(damage);
        Health += value;

        CheckHealth();
    }

    public int CheckCurrentHealth()
    {
        return Health;
    }

    private int CheckValue(int value)
    {
        if (value >= 0)
            return value;
        else
            return 0;
    }

    private void CheckHealth()
    {
        if (Health < _minHealth)
            Health = _minHealth;
        if (Health > _maxHealth)
            Health = _maxHealth;
    }
}