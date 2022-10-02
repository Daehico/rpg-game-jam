using Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DrinkBlood : Spell
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _player;
    [SerializeField] private int _heal;

    private const string DrinkBloodAnimation = "DrinkBloodAnimation";

    public override void Cast(Enemy.EnemyHealth target)
    {
        var mover = Instantiate(TemplateSpell, target.transform).GetComponent<SpellMover>(); ;
        mover.Init(_player, _heal);
        StartCoroutine(AnimationDelay(_animator.GetCurrentAnimatorClipInfo(0).Length));
    }

    private IEnumerator AnimationDelay(float delay)
    {
        _animator.SetBool(DrinkBloodAnimation, true);

        yield return new WaitForSeconds(delay);

        _animator.SetBool(DrinkBloodAnimation, false);
    }
}
