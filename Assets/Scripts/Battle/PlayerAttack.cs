using Enemy;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerAttack : MonoBehaviour
{
    private PlayerDamage _damage;
    private PlayerMovement _playerMovement;
    private float _time, _cooldown = 1f;
    private Camera _camera;

    [SerializeField] private float _minAttackDistance = 4f;
    
    public event UnityAction<EnemyHealth> OnAttack;
    
    private void Awake()
    {
        _damage = FindObjectOfType<PlayerDamage>();
        _camera = FindObjectOfType<Camera>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (_time < Time.time && Input.GetMouseButton(1))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit raycastHit) 
                && raycastHit.transform.TryGetComponent(
                        out EnemyHealth enemyHealth)
                && IsAttckDistance(enemyHealth.transform.position))
            {
                _time = Time.time + _cooldown;
                enemyHealth.ApplyDamage(_damage.Damage);
                _playerMovement.MoveCooldown(_time);
                OnAttack?.Invoke(enemyHealth);
                Debug.Log("Attack " + _damage.Damage + " EnemyHealth = " + enemyHealth.CurrentHealth);
            }
        }
    }

    private bool IsAttckDistance(Vector3 enemyPosition)
    {
        var distance = (enemyPosition - transform.position).magnitude;
        return distance < _minAttackDistance;
    }
}
