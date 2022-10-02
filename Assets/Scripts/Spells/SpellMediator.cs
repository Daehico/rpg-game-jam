using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellMediator : MonoBehaviour
{
    [SerializeField] private PlayerAttack _playerAttack;
    [SerializeField] private List<Spell> _spells;

    private void OnEnable()
    {
        _playerAttack.OnAttack += OnPlayerAttack;
    }

    private void OnDisable()
    {
        _playerAttack.OnAttack -= OnPlayerAttack;
    }

    private void OnPlayerAttack(Enemy.EnemyHealth enemyHealth)
    {
        for (int i = 0; i < _spells.Count; i++)
        {
            _spells[i].SetTarget(enemyHealth);
        }

        _spells[0].PrepareToCast();
    }
}
