using UnityEngine;

public class SpellMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private Transform _target;

    private void Update()
    {
        if (_target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _moveSpeed * Time.deltaTime);
        }      
    }

    public void Init(Transform target)
    {
        _target = target;
    }
}
