using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class WeaponInput : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private WeaponStateMachine _weaponStateMachine;

    public PlayerControls Controls { get; private set; }
    private CompositeDisposable _disposable = new CompositeDisposable();

    private void Awake()
    {
        Controls = new PlayerControls();
    }

    private void OnEnable()
    {
        Controls.Enable();

        Controls.Main.Shoot.started += context => CheckShooting();
        Controls.Main.Shoot.canceled += context => _disposable.Clear();
        StartCoroutine(Run());
    }

    private void OnDisable()
    {
        Controls.Main.Shoot.started -= context => CheckShooting();
        Controls.Main.Shoot.canceled -= context => _disposable.Clear();
        Controls.Disable();
        _disposable.Clear();
        StopCoroutine(Run());
        StopAllCoroutines();
    }

    private void CheckShooting()
    {
        Observable.EveryFixedUpdate().Subscribe(_ =>
        {
            if (Controls.Main.Shoot.IsPressed() && (Time.timeScale >= 1))
            {
                _weaponStateMachine.Shoot();
                return;
            }
        }).AddTo(_disposable);
    }

    private IEnumerator Run()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(0.02f);
            if (_weaponStateMachine.StateMachine.CurrentState.CanChangeState == false)
                continue;

            if (Controls.Main.MoveForwardBackward.ReadValue<float>() == 0 &&
                Controls.Main.MoveLeftRight.ReadValue<float>() == 0)
            {
                _weaponStateMachine.Idle();
                continue;
            }
            else if (_playerMovement.CharacterController.isGrounded)
            {
                _weaponStateMachine.Walk();
                continue;
            }

            _weaponStateMachine.Idle();
        }
    }
}