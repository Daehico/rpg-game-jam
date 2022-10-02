using Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoHandedBlow : Spell
{
    [SerializeField] private Animator _animator;
    [SerializeField] private int _damage;

    private const string TwoHandedBlowAnimation = "TwoHandedBlowAnimation";

    protected override void Cast(EnemyHealth target)
    {
        target.ApplyDamage(_damage);
        Instantiate(TemplateSpell, target.transform);

        StartCoroutine(AnimationDelay(_animator.GetCurrentAnimatorClipInfo(0).Length));
    }

    private IEnumerator AnimationDelay(float delay)
    {
        _animator.SetBool(TwoHandedBlowAnimation, true);

        yield return new WaitForSeconds(delay);

        _animator.SetBool(TwoHandedBlowAnimation, false);
    }
}
