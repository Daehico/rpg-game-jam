using Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DrinkBlood : Spell
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerHealth _player;
    [SerializeField] private int _heal;
    [SerializeField] private Transform _particlePoint;

    private const string StreamOfBloodAnimation = "StreamOfBloodAnimation";

    protected override void Cast(Enemy.EnemyHealth target)
    {
        var mover = Instantiate(TemplateSpell, target.transform.position, Quaternion.identity).GetComponent<SpellMover>(); ;
        mover.Init(_particlePoint.transform);
        _player.Treatment(_heal);
        StartCoroutine(AnimationDelay(_animator.GetCurrentAnimatorClipInfo(0).Length));
    }

    private IEnumerator AnimationDelay(float delay)
    {
        _animator.SetBool(StreamOfBloodAnimation, true);

        yield return new WaitForSeconds(delay);

        _animator.SetBool(StreamOfBloodAnimation, false);
    }
}
