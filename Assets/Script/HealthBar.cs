using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _speedHealthChanging = 100;

    private Slider _slider;
    private Coroutine _corutine;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _player.HealthChanged += OnSetSliderMaxValue;
        _player.HealthChanged -= OnSetSliderMaxValue;
    }

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private IEnumerator ChangeHealthCorutine(float health)
    {
        var waitForEndFrame = new WaitForEndOfFrame();

        while(_slider.value != health)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, health, _speedHealthChanging * Time.deltaTime);
            yield return waitForEndFrame;
        }
    }

    private void OnHealthChanged(float health)
    {
        if (_corutine != null)
            StopCoroutine(_corutine);

        _corutine = StartCoroutine(ChangeHealthCorutine(health));
    }

    private void OnSetSliderMaxValue(float health)
    {
        _slider.maxValue = health;
        _slider.value = health;
    }
}