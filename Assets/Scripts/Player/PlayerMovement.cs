using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    private const string RunAnimation = "IsRun";
    
    private Animator _animator;
    private CameraPlacer _cameraPlacer;
    private float _cooldownTime;
    private Camera _camera;

    [SerializeField] private NavMeshAgent _agent;

    public bool CanMove => _cooldownTime < Time.time;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _cameraPlacer = FindObjectOfType<CameraPlacer>();
        _camera = FindObjectOfType<Camera>();
        _cameraPlacer.SetPosition(transform);
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit raycastHit) && CanMove)
            {
                _agent.SetDestination(raycastHit.point);
                _animator.SetBool(RunAnimation, true);
            }
        }

        if (Vector3.Distance(transform.position, _agent.destination) <= 0.5f)
        {
            _animator.SetBool(RunAnimation, false);
        }

        _agent.isStopped = !CanMove;
    }

    public void MoveCooldown(float time)
    {
        if (time < _cooldownTime)
            return;

        _cooldownTime = time;
        _animator.SetBool(RunAnimation, false);
    }
}
