using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    private NavMeshAgent _agent;
    private RaycastHit hit;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    public void OnMove(InputValue value)
    {
        SetDestinationToMousePosition();
        Debug.Log("move!");
    }
    public void SetDestinationToMousePosition()
    {
        if (Camera.main is { })
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out hit))
            {
                _agent.SetDestination(hit.point);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(hit.point, 0.5f);
    }
}
