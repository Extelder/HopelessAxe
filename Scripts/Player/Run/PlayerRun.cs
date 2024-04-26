using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : MonoBehaviour
{
    [SerializeField] private float _runSpeed;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerInputs _inputs;

    private void OnEnable()
    {
        _inputs.RunInput.RunButtonDown += Run;
        _inputs.RunInput.RunButtonUp += StopRun;
    }

    private void OnDisable()
    {
        _inputs.RunInput.RunButtonDown -= Run;
        _inputs.RunInput.RunButtonUp -= StopRun;
    }

    private void Run()
    {
        _playerMovement.TargetSpeed = _runSpeed;
    }

    private void StopRun()
    {
        _playerMovement.TargetSpeed = _playerMovement.StartSpeed;
    }
}