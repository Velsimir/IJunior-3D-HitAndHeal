using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using System;

public class Player : MonoBehaviour
{
    [Range(1, 1000)]
    [SerializeField] private float _health;

    private float _minHealth = 0;
    private float _maxHealth = 1000;

    public event Action<float> HealthChanged;

    private void Start()
    {
        HealthChanged?.Invoke(_health);
    }

    public void TakeDamage(int damage)
    {
        if (_health - damage > _minHealth)
            _health -= damage;
        else
            _health = _minHealth;

        HealthChanged?.Invoke(_health);
    }

    public void TakeHeal(int heal)
    {
        if (_health + heal < _maxHealth)
            _health += heal;
        else
            _health = _maxHealth;

        HealthChanged?.Invoke(_health);
    }
}