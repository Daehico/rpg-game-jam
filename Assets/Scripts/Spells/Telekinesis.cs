using Enemy;
using System.Collections;
using UnityEngine;

public class Telekinesis : Spell
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _telekinesisSpeed;
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _telekinesisPoint;

    private const string TelekinesisAnimation = "TelekinesisAnimation";

    public override void Cast(EnemyHealth target)
    {
        StartCoroutine(AnimationDelay(_animator.GetCurrentAnimatorClipInfo(0).Length));
        StartCoroutine(MoveObject(target.gameObject.transform));
    }

    private IEnumerator AnimationDelay(float delay)
    {
        _animator.SetBool(TelekinesisAnimation, true);

        yield return new WaitForSeconds(delay);

        _animator.SetBool(TelekinesisAnimation, false);
    }

    private IEnumerator MoveObject(Transform target)
    {
        while (Vector3.Distance(target.position, _telekinesisPoint.position) <= 0.2f)
        {
            target.position = Vector3.MoveTowards(target.position, _telekinesisPoint.transform.position, _telekinesisSpeed * Time.deltaTime);
            yield return null;
        }

        target.SetParent(_player);
    }
}
