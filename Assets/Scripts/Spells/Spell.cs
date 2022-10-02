using UnityEngine;
using UnityEngine.Events;

public abstract class Spell : MonoBehaviour
{
    [SerializeField] private protected float Cooldown;
    [SerializeField] private protected GameObject TemplateSpell;
    [SerializeField] private float _minAttackDistance = 4f;

    private protected bool CanCast = false;

    private float _timeRemaining;
    private Enemy.EnemyHealth _target;
    private bool _isUnlock = false;

    public bool IsUnlock => _isUnlock;

    public event UnityAction Unlocked;

    private void Start()
    {
        _timeRemaining = Cooldown;
    }

    private void Update()
    {
        if (CanCast != true)
            ÑooldownCounter();
    }

    protected abstract void Cast(Enemy.EnemyHealth target);

    public void Unlock()
    {
        _isUnlock = true;
    }

    public void SetTarget(Enemy.EnemyHealth target)
    {
        _target = target;
    }

    public void PrepareToCast()
    {
        if (_target != null)
        {
            if (CanCast)
            {
                if(IsAttckDistance(_target.transform.position))
                {
                    _timeRemaining = Cooldown;
                    CanCast = false;
                    Cast(_target);
                }             
            }          
        }
    }

    private bool IsAttckDistance(Vector3 enemyPosition)
    {
        var distance = (enemyPosition - transform.position).magnitude;
        return distance < _minAttackDistance;
    }

    private void ÑooldownCounter()
    {
        if (_timeRemaining > 0)
            _timeRemaining -= Time.deltaTime;
        else
            CanCast = true;
    }
}
