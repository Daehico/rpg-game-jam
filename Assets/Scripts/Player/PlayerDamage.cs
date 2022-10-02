using System;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private int _baseDamage;

    private int _damage;
    private PlayerEquip _playerEquip;

    public int Damage => _damage;

    private void Awake()
    {
        _damage = _baseDamage;
        _playerEquip = FindObjectOfType<PlayerEquip>();
    }

    private void OnEnable()
    {
        _playerEquip.WeponSet += ChangeDamage;
    }

    private void OnDisable()
    {
        _playerEquip.WeponSet -= ChangeDamage;
    }

    private void ChangeDamage()
    {
        Weapon weapon = _playerEquip.Weapon as Weapon;
        _damage += weapon.Damage;
    }
}
