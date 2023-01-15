using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Range(1,1000)]
    [SerializeField] private int Health;

    public void TakeDamage(int damage)
    {
        int value = CheckValue(damage);
        Health -= value;

        if (Health < 0)
            Health = 0;
    }

    public void TakeHeal(int damage)
    {
        int value = CheckValue(damage);
        Health += value;

        if (Health > 1000)
            Health = 1000;
    }

    public int CheckHealth()
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
}