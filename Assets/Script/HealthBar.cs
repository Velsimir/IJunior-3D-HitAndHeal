using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _speed;

    private Slider _slider;
    private float _maxHealth;

    private void Start()
    {
        _slider = GetComponentInChildren<Slider>();
        _slider.maxValue = _player.CheckCurrentHealth();
        _slider.value = _player.CheckCurrentHealth();

        _maxHealth = _player.CheckCurrentHealth();
    }

    private void Update()
    {
        _slider.value = Mathf.MoveTowards(_slider.value, _player.CheckCurrentHealth(), _speed * Time.deltaTime);
    }
}
