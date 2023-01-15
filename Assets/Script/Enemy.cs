using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Range(1,500)]
    [SerializeField] private int _damage;
    [SerializeField] private Player _player;

    public void Attack()
    {
        _player.TakeDamage(_damage);
    }
}
