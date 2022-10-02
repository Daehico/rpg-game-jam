using System.Collections;
using Enemy;
using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
public class EnemyAttack : MonoBehaviour
{
    private Coroutine _coroutine;
        
    [SerializeField] private int _damage;
    
    private void OnTriggerEnter(Collider other)
    {
        if (_coroutine == null && 
            other.gameObject.TryGetComponent(out PlayerHealth playerHealth))
        {
            MakeDamage(playerHealth);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_coroutine != null && 
            other.gameObject.TryGetComponent(out PlayerHealth playerHealth))
        {
            StopCoroutine(_coroutine);
        }
    }

    private void MakeDamage(PlayerHealth playerHealth)
    {
        _coroutine = StartCoroutine(AttackWithDelay(playerHealth));
    }

    private IEnumerator AttackWithDelay(PlayerHealth playerHealth)
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            playerHealth.ApplyDamage(_damage);
        }
    }
}
