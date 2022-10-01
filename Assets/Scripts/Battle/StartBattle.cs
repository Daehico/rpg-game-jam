using System.Collections;
using System.Collections.Generic;
using Enemy;
using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
public class StartBattle : MonoBehaviour
{
    private EnemyHealth _enemyHealth;

    private void Awake()
    {
        _enemyHealth = GetComponent<EnemyHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out PlayerHealth playerHealth))
        {
            _enemyHealth.MakeDamage(playerHealth);
            playerHealth.GetComponent<PlayerAttack>().StartBattle(_enemyHealth);
        }
    }
}
