using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private NavMeshAgent _agent;

    private const string RunAnimation = "IsRun";

    private Animator _animator;
    private bool _canMove = true;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void CanMove()
    {
        _canMove = true;
    }

    public void CantMove()
    {
        _canMove = false;
        _animator.SetBool(RunAnimation, false);
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit raycastHit) && _canMove == true)
            {
                _agent.SetDestination(raycastHit.point);
                _animator.SetBool(RunAnimation, true);
            }
        }

        if (Vector3.Distance(transform.position, _agent.destination) <= 0.5f)
        {
            _animator.SetBool(RunAnimation, false);
        }

        _agent.isStopped = !_canMove;
    }
}
