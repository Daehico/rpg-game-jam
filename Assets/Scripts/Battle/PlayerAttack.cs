using System;
using System.Collections;
using Enemy;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private const string AttackAnimation = "IsAttack";

    private bool _isInBattle = false;
    private PlayerDamage _damage;
    private EnemyHealth _enemyHealth;
    private PlayerMovement _playerMovement;
    private Animator _animator;

    private void Awake()
    {
        _damage = FindObjectOfType<PlayerDamage>();
        _playerMovement = GetComponent<PlayerMovement>();
        _animator = GetComponent<Animator>();
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
                        _animator.SetBool(AttackAnimation,true);
                        StartCoroutine(AnimationDelay(_animator.GetCurrentAnimatorClipInfo(0).Length));
                    }
                }              
            }
            else
            {
                _playerMovement.CantMove();               
            }
        }
    }

    private IEnumerator AnimationDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        _animator.SetBool(AttackAnimation, false);
    }
}
