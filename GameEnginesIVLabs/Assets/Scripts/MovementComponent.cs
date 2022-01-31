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
    
    private Vector2 inputDirection;
    private Vector3 moveDirection;

    private PlayerController _playerController;
    private Animator _animator;
    

    public readonly int movementXHash = Animator.StringToHash("MovementX");
    public readonly int movementYHash = Animator.StringToHash("MovementY");
    public readonly int jumpHash = Animator.StringToHash("Jump");
    public readonly int RunHash = Animator.StringToHash("Run");
    public readonly int AimingHash = Animator.StringToHash("Aiming");
    void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _animator = transform.Find("model").GetComponent<Animator>();
    }

    private void Update()
    {
        if (_playerController.isJumping) return;
        if(inputDirection.magnitude == 0) moveDirection = Vector3.zero;

        moveDirection = inputDirection.y * transform.forward + inputDirection.x * transform.right;
        float currentSpeed = _playerController.isRunning ? runSpeed : walkSpeed;
        transform.position += moveDirection * (currentSpeed * Time.deltaTime);
    }

    public void OnMovement(InputValue value)
    {
        inputDirection = value.Get<Vector2>();
        _animator.SetFloat(movementXHash,  inputDirection.x);
        _animator.SetFloat(movementYHash, inputDirection.y);
    }

    public void OnJump(InputValue value)
    {
        _playerController.isJumping = value.isPressed;
        _animator.SetBool(jumpHash, _playerController.isJumping);
    }

    public void OnRun(InputValue value)
    {
        _playerController.isRunning = value.isPressed;
    }

    public void OnAim(InputValue value)
    {
        _playerController.isAiming = value.isPressed;
        _animator.SetBool(AimingHash, _playerController.isAiming);
    }
    
}
