using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    private Animator _animator;
    private NavMeshAgent _agent;

    private readonly int _autoAttackHash = Animator.StringToHash("AutoAttack");

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
    }
    public void OnAutoAttack(InputValue value)
    {
        _animator.SetTrigger(_autoAttackHash);
        _agent.isStopped = true;
    }
}
