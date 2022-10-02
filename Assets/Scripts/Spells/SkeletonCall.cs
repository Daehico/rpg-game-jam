using Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonCall : Spell
{
    [SerializeField] private Animator _animator;

    private const string SkeletonCallAnimation = "SkeletonCallAnimation";

    public override void Cast(EnemyHealth target)
    {
        Instantiate(TemplateSpell, target.transform);
        StartCoroutine(AnimationDelay(_animator.GetCurrentAnimatorClipInfo(0).Length));
    }

    private IEnumerator AnimationDelay(float delay)
    {
        _animator.SetBool(SkeletonCallAnimation, true);

        yield return new WaitForSeconds(delay);

        _animator.SetBool(SkeletonCallAnimation, false);
    }
}
