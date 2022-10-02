using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreamOfBlood : Spell
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private int _damage;

    private const string StreamOfBloodAnimation = "StreamOfBloodAnimation";

    protected override void Cast(Enemy.EnemyHealth target)
    {
        var mover = Instantiate(TemplateSpell, _shootPoint.position, Quaternion.identity).GetComponent<SpellMover>();
        mover.Init(target.transform);
        target.ApplyDamage(_damage);
        StartCoroutine(AnimationDelay(_animator.GetCurrentAnimatorClipInfo(0).Length));
    }

    private IEnumerator AnimationDelay(float delay)
    {
        _animator.SetBool(StreamOfBloodAnimation, true);

        yield return new WaitForSeconds(delay);

        _animator.SetBool(StreamOfBloodAnimation, false);
    }
}
