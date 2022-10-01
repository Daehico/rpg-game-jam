using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private NavMeshAgent _agent;

    private bool _canMove = true;

    public void CanMove()
    {
        _canMove = true;
    }

    public void CantMove()
    {
        _canMove = false;
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out RaycastHit raycastHit) && _canMove == true)
            {
                _agent.SetDestination(raycastHit.point);
            }
        }

        _agent.isStopped = !_canMove;
    }
}
