using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    private NavMeshAgent _agent;
    private RaycastHit _hit;
    private Animator _animator;
    
    private readonly int _isMovingHash = Animator.StringToHash("isMoving");

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!_agent.hasPath || _agent.isStopped)
        {
            _animator.SetBool(_isMovingHash, false);
        }
    }

    public void OnMove(InputValue value)
    {
        SetDestinationToMousePosition();
        _agent.isStopped = false;
    }
    
    public void SetDestinationToMousePosition()
    {
        if (Camera.main is { })
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out _hit))
            {
                _agent.SetDestination(_hit.point);
                _animator.SetBool(_isMovingHash, true);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(_hit.point, 0.5f);
    }
}
