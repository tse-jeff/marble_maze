using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_rotation : MonoBehaviour
{

    public float _mouseSensitivity = 3;
    public Transform _target;
    public float _distanceFromTarget = 15;

    private float _rotationX;
    private float _rotationY;
    private Vector3 _currentRotation;
    private Vector3 _soomthVelocity = Vector3.zero;
    [SerializeField] private float _smoothTime = 0.1f;

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity;

        _rotationY += mouseX;
        _rotationX += mouseY;

        _rotationX = Mathf.Clamp(_rotationX, -40, 40);

        Vector3 nextRotation = new Vector3(-_rotationX, _rotationY);
        _currentRotation = Vector3.SmoothDamp(_currentRotation, nextRotation, ref _soomthVelocity, _smoothTime);

        transform.localEulerAngles = _currentRotation;
        transform.position = _target.position - transform.forward * _distanceFromTarget;

    }
}
