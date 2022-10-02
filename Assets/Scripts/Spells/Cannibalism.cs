using Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannibalism : Spell
{
    [SerializeField] private Animator _animator;
    [SerializeField] private int _heal;
    [SerializeField] private PlayerHealth _playerHealth;

    private const string CannibalismAnimation = "CannibalismAnimation";

    protected override void Cast(EnemyHealth target)
    {
        Instantiate(TemplateSpell, target.transform);
        _playerHealth.Treatment(_heal);
        StartCoroutine(AnimationDelay(_animator.GetCurrentAnimatorClipInfo(0).Length));
    }

    private IEnumerator AnimationDelay(float delay)
    {
        _animator.SetBool(CannibalismAnimation, true);

        yield return new WaitForSeconds(delay);

        _animator.SetBool(CannibalismAnimation, false);
    }
}
