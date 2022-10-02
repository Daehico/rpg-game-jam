using Enemy;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerAttack : MonoBehaviour
{
    private Camera _camera;

    public event UnityAction<EnemyHealth> OnAttack;

    private void Awake()
    {      
        _camera = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit raycastHit)
                && raycastHit.transform.TryGetComponent(
                        out EnemyHealth enemyHealth))
                OnAttack?.Invoke(enemyHealth);
        }
    }
}
