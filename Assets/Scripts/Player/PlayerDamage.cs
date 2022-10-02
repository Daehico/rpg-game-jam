using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private int _baseDamage;

    private int _damage;

    public int Damage => _damage;

    private void Awake()
    {
        _damage = _baseDamage;
    }
}
