using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class CameraPlacer : MonoBehaviour
{
    private CinemachineVirtualCamera _camera;

    private void Awake()
    {
        _camera = GetComponent<CinemachineVirtualCamera>();
    }

    public void SetPosition(Transform transform)
    {
        _camera.Follow = transform;
        _camera.LookAt = transform;
    }
}
