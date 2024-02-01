using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [Header("Configuration")]
    [Header("Move camera")]
    [SerializeField]
    private float _cameraMovementSpeed = 20.0f;
    [Header("Rotate camera")]
    [SerializeField]
    private float _cameraRotateSpeed = 15.0f;
    [Header("Zoom camera")]
    [SerializeField]
    private float _fieldOfViewMin = 5f;
    [SerializeField]
    private float _fieldOfViewMax = 50f;

    private float _targetFieldOfView = 50;
    private CinemachineVirtualCamera _cinemachineVirtualCamera;
    private Vector3 _movementInput;
    private float _rotateInput;
    private Vector3 _moveDir = Vector3.zero;

    private void Start()
    {
        _cinemachineVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        //Rotate camera
        transform.eulerAngles += new Vector3(0, _rotateInput * _cameraRotateSpeed * Time.deltaTime, 0);
        //Move camera
        transform.position += _moveDir.normalized * _cameraMovementSpeed * Time.deltaTime;
    }

    #region Camera functions
    public void OnHandleCameraMove(InputAction.CallbackContext context)
    {
            _movementInput = context.ReadValue<Vector3>();
            // Create a vector 3 that works independently of the angle used by the camera
            _moveDir = transform.forward * _movementInput.z + transform.right * _movementInput.x;
    }

    public void OnHandleCameraRotate(InputAction.CallbackContext context)
    {
        _rotateInput = context.ReadValue<float>();
    }

    public void OnHandleCameraZoom(InputAction.CallbackContext context)
    {
        float fieldOfViewIncreaseAmout = 5f;
        if (context.ReadValue<float>() < 0)
        {
            _targetFieldOfView += fieldOfViewIncreaseAmout;
        }
        if (context.ReadValue<float>() > 0)
        {
            _targetFieldOfView -= fieldOfViewIncreaseAmout;
        }
        _targetFieldOfView = Mathf.Clamp(_targetFieldOfView, _fieldOfViewMin, _fieldOfViewMax);
        _cinemachineVirtualCamera.m_Lens.FieldOfView = _targetFieldOfView;
    }
    #endregion
}
