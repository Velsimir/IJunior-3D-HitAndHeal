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

    private void Start()
    {
        _slider = GetComponentInChildren<Slider>();
        _slider.maxValue = _player.Health;
        _slider.value = _player.Health;
    }

    private void Update()
    {
        _slider.value = _player.Health;
    }
}
