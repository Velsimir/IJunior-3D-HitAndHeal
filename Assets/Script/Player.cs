using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player : MonoBehaviour
{
    [Range(1,1000)]
    [SerializeField] private float _health;
    [SerializeField] private float _speedHealthChanging;

    private float _minHealth = 0;
    private float _maxHealth = 1000;

    public float Health {get {return _health; } private set { } }


    public void TakeDamage(int damage)
    {
        if (_health - damage > _minHealth)
        {
            StartCoroutine(ChangeHealthCorutine(damage));
        }
        else
        {
            StartCoroutine(ChangeHealthCorutine(_minHealth));
        }

        StopCoroutine(ChangeHealthCorutine(damage));
    }

    public void TakeHeal(int heal)
    {
        heal = -heal;

        if (heal + _health < _maxHealth)
        {
            StartCoroutine(ChangeHealthCorutine(heal));
        }
        else
        {
            StartCoroutine(ChangeHealthCorutine(_maxHealth));
        }

        StopCoroutine(ChangeHealthCorutine(heal));
    }

    private IEnumerator ChangeHealthCorutine(float value)
    {
        var waitForEndFrame = new WaitForEndOfFrame();
        float targetHealth = _health - value;

        do
        {
            _health = Mathf.MoveTowards(_health, targetHealth, _speedHealthChanging * Time.deltaTime);
            yield return waitForEndFrame;

        } while (_health != targetHealth);
    }
}