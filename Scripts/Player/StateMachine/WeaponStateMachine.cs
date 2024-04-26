using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStateMachine : MonoBehaviour
{
    [Space(-10)] [Header("Weapon States")] [SerializeField]
    private WeaponState _idleState;

    [SerializeField] private WeaponState _walkState;
    [SerializeField] private WeaponState _shootState;

    public StateMachine StateMachine { get; private set; }

    private void Awake()
    {
        StateMachine = new StateMachine();
        StateMachine.Init(_idleState);
    }

    private void OnDisable()
    {
        StateMachine.CurrentState.CanChangeState = true;
        Idle();
    }

    public void Idle()
    {
        StateMachine.ChangeState(_idleState);
    }

    public void Walk()
    {
        StateMachine.ChangeState(_walkState);
    }

    public void Shoot()
    {
        StateMachine.ChangeState(_shootState);
    }

    public void Reload()
    {
    }
}