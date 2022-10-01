using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class StartBattle : MonoBehaviour
{
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out PlayerHealth playerHealth))
        {
            _enemy.MakeDamage(playerHealth);
            playerHealth.GetComponent<PlayerAttack>().StartBattle(_enemy);
        }
    }
}
