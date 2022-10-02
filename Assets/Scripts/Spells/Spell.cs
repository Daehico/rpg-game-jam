using UnityEngine;
using UnityEngine.Events;

public abstract class Spell : MonoBehaviour
{
    [SerializeField] private protected float Cooldown;
    [SerializeField] private protected GameObject TemplateSpell;

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

    public abstract void Cast(Enemy.EnemyHealth target);

    public void Unlock()
    {
        _isUnlock = true;
    }

    public void SetTarget(Enemy.EnemyHealth target)
    {
        _target = target;
    }

    public void PrepareToCast(Enemy.EnemyHealth target)
    {
        if (target != null)
        {
            if (CanCast)
            {
                _timeRemaining = Cooldown;
                CanCast = false;
                Cast(target);
            }          
        }
    }  

    private void ÑooldownCounter()
    {
        if (_timeRemaining > 0)
            _timeRemaining -= Time.deltaTime;
        else
            CanCast = true;
    }
}
