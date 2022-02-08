using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementComponent : MonoBehaviour
{
    public float walkSpeed = 5;
    public float runSpeed = 10;
    public float jumpForce = 5;

    [Header("Camera")] 
    public int maxAngle = 340;
    public int minAngle = 40;
    public float aimSensitivity = 1.0f;
    public GameObject followObject;
    
    private Vector2 _inputDirection;
    private Vector3 _moveDirection;
    private Vector2 _lookDirection;

    private PlayerController _playerController;
    private Animator _animator;
    

    private readonly int _movementXHash = Animator.StringToHash("MovementX");
    private readonly int _movementYHash = Animator.StringToHash("MovementY");
    private readonly int _jumpHash = Animator.StringToHash("Jump");
    private readonly int _runHash = Animator.StringToHash("Run");
    
    void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _animator = transform.Find("model").GetComponent<Animator>();
    }

    private void Update()
    {
        #region CameraMovement With Mouse

        var rotation = followObject.transform.rotation;
        rotation *= Quaternion.AngleAxis(_lookDirection.x * aimSensitivity * Time.deltaTime, Vector3.up);
        rotation *= Quaternion.AngleAxis(_lookDirection.y * aimSensitivity * Time.deltaTime, Vector3.left);
        followObject.transform.rotation = rotation;

        var angles = followObject.transform.eulerAngles;
        angles.z = 0;
        var angle = followObject.transform.localEulerAngles.x;
        
        if (angle > 180 && angle < maxAngle)
        {
            angles.x = maxAngle;
        }else if (angle < 180 && angle > minAngle)
        {
            angles.x = minAngle;
        }

        followObject.transform.localEulerAngles = angles;
        #endregion
        
        if (_playerController.isJumping) return;
        if(_inputDirection.magnitude == 0) _moveDirection = Vector3.zero;

        _moveDirection = _inputDirection.y * transform.forward + _inputDirection.x * transform.right;
        float currentSpeed = _playerController.isRunning ? runSpeed : walkSpeed;
        transform.position += _moveDirection * (currentSpeed * Time.deltaTime);
        
    }

    public void OnMovement(InputValue value)
    {
        _inputDirection = value.Get<Vector2>();
        _animator.SetFloat(_movementXHash,  _inputDirection.x);
        _animator.SetFloat(_movementYHash, _inputDirection.y);
    }

    public void OnJump(InputValue value)
    {
        _playerController.isJumping = value.isPressed;
        _animator.SetBool(_jumpHash, _playerController.isJumping);
    }

    public void OnLook(InputValue value)
    {
        _lookDirection = value.Get<Vector2>();
    }
    public void OnRun(InputValue value)
    {
        _playerController.isRunning = value.isPressed;
    }

}
