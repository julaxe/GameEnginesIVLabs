using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponHolder : MonoBehaviour
{
    public WeaponController weaponController;

    private Animator _animator;
    private PlayerController _playerController;
    
    private readonly int _aimingHash = Animator.StringToHash("Aiming");
    private readonly int _firingHash = Animator.StringToHash("Firing");
    private readonly int _reloadingHash = Animator.StringToHash("Reloading");
    
    void Awake()
    {
        _animator = transform.Find("model").GetComponent<Animator>();
        _playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnAnimatorIK(int layerIndex)
    {
        //if (_playerController.isReloading) return;
        _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1.0f);
        _animator.SetIKPosition(AvatarIKGoal.LeftHand, weaponController.socketIKLeftHand.position);
    }

    public void OnAim(InputValue value)
    {
        _playerController.isAiming = value.isPressed;
        _animator.SetBool(_aimingHash, _playerController.isAiming);
    }

    public void OnFire(InputValue value)
    {
        _playerController.isFiring = value.isPressed;
        _animator.SetBool(_firingHash, _playerController.isFiring);
    }
    
    public void OnReload(InputValue value)
    {
        _playerController.isReloading = value.isPressed;
        _animator.SetBool(_reloadingHash, _playerController.isReloading);
        
    }

    
    
}
