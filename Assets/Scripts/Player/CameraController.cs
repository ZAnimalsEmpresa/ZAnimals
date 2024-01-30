using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float _cameraMovementSpeed = 20.0f;
    private Vector3 _movementInput;

    private void Update()
    {
        transform.position += _movementInput.normalized * _cameraMovementSpeed * Time.deltaTime;
    }

    private void OnHandleCameraMove(InputValue value)
    {
        _movementInput = value.Get<Vector3>();
    }
}
