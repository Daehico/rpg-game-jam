using System;
using Enemy;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private bool _isInBattle = false;
    private PlayerDamage _damage;
    private EnemyHealth _enemyHealth;
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _damage = FindObjectOfType<PlayerDamage>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    public void StartBattle(EnemyHealth enemyHealth)
    {
        if (enemyHealth == null)
            throw new NullReferenceException("Enemy can't be null");

        _enemyHealth = enemyHealth;
        _isInBattle = true;
    }

    private void Update()
    {
        if (_isInBattle)
        {
            if (Input.GetMouseButton(1))
            {
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit raycastHit))
                {
                    if (_enemyHealth.transform == raycastHit.transform)
                    {
                        _enemyHealth.ApplyDamage(_damage.Damage);
                        _playerMovement.CantMove();
                    }
                }              
            }
            else
            {
                _playerMovement.CantMove();
            }
        }
    }
}
