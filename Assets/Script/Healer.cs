using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : MonoBehaviour
{
    [Range(1, 500)]
    [SerializeField] private int _heal;
    [SerializeField] private Player _player;

    public void Heal()
    {
        _player.TakeHeal(_heal);
    }
}