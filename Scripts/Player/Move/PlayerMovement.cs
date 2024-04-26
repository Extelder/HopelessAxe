using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerInputs _inputs;
    [SerializeField] private float _transitionToMaxSpeed;
    [field: SerializeField] public float TargetSpeed { get; set; }
    public float StartSpeed { get; private set; }

    public CharacterController CharacterController { get; private set; }

    private float _currentSpeed;

    private void Awake()
    {
        CharacterController = GetComponent<CharacterController>();

        StartSpeed = TargetSpeed;
    }

    private void Update()
    {
        _currentSpeed = Mathf.Lerp(_currentSpeed, TargetSpeed, _transitionToMaxSpeed * Time.deltaTime);

        Vector3 MoveDirection = new Vector3(_inputs.MoveAxisInput.InputAxis.x * _currentSpeed, 0,
            _inputs.MoveAxisInput.InputAxis.y * _currentSpeed) * Time.deltaTime;
        MoveDirection = transform.TransformDirection(MoveDirection);

        CharacterController.Move(MoveDirection);
    }
}