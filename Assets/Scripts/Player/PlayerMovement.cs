using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;
using Upgrade;

[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour, IUpgradable
{
    private const string RunAnimation = "IsRun";
    
    private Animator _animator;
    private CameraPlacer _cameraPlacer;
    private float _cooldownTime;
    private Camera _camera;
    private Vector3 _target;

    [SerializeField] private NavMeshAgent _agent;

    public bool CanMove => _cooldownTime < Time.time;

    private bool InTargetPoint =>
        Vector3.Distance(transform.position, _agent.destination) <= 0.5f;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _cameraPlacer = FindObjectOfType<CameraPlacer>();
        _camera = FindObjectOfType<Camera>();
        //_cameraPlacer.SetPosition(transform);
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

        if (InTargetPoint)
        {
            _animator.SetBool(RunAnimation, false);
        }

        _agent.isStopped = !CanMove || InTargetPoint;
    }

    public void Stop()
    {
        _agent.SetDestination(transform.position);
    }

    public void MoveCooldown(float time)
    {
        if (time < _cooldownTime)
            return;

        _cooldownTime = time;
        Stop();
    }

    public void Upgrade(int value)
    {
        _agent.speed = value;
    }
}
