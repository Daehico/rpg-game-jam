using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class SpellMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private Transform _target;
    private int _value;

    private void Update()
    {
        if (_target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy.EnemyHealth enemy))
        {
            enemy.ApplyDamage(_value);
        }

        if(other.TryGetComponent(out PlayerHealth player))
        {
            player.Treatment(_value);
        }

        Destroy(gameObject);
    }

    public void Init(Transform target, int value)
    {
        _target = target;
        _value = value;
    }
}
