using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _sensitivity;
    [SerializeField] private float _minAngleY;
    [SerializeField] private float _maxAngleY;
    
    private float _moveX, _moveY;
   
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        float sensitivity = _sensitivity;
        _moveX = Input.GetAxis("Mouse X")*sensitivity;
        _moveY += Input.GetAxis("Mouse Y")*sensitivity;
        _moveY = Mathf.Clamp(_moveY, _minAngleY, _maxAngleY);
        transform.localRotation = Quaternion.Euler(-_moveY, 0, 0);
        _playerTransform.Rotate(Vector3.up * (_moveX * sensitivity));
    }
}
