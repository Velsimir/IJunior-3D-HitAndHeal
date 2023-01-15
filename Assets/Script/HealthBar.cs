using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Slider _slider;
    private float _maxHealth;

    private void Start()
    {
        _slider = GetComponentInChildren<Slider>();
        _maxHealth = _player.CheckHealth();
    }

    private void Update()
    {
        _slider.value = _player.CheckHealth() / _maxHealth;
    }
}
