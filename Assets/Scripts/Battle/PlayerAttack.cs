using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private bool _isInBattle = false;
    private PlayerDamage _damage;
    private Enemy _enemy;
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _damage = FindObjectOfType<PlayerDamage>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    public void StartBattle(Enemy enemy)
    {
        if (enemy == null)
            throw new NullReferenceException("Enemy can't be null");

        _enemy = enemy;
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
                    if (_enemy.transform == raycastHit.transform)
                    {
                        _enemy.ApplyDamage(_damage.Damage);
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
