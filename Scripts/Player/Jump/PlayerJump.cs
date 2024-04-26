using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(CharacterController))]
public class PlayerJump : MonoBehaviour
{
    [SerializeField] private PlayerGround _ground;
    [SerializeField] private float _gravity = -4f;
    [SerializeField] private float _gravityScale = 1;
    [SerializeField] private float _jumpHeight = 10;
    [SerializeField] private PlayerInputs _inputs;
    
    private CharacterController _characterController;
    private float _velocity;

    private void OnEnable()
    {
        _inputs.JumpInput.Jump += Jump;
    }

    private void OnDisable()
    {
        _inputs.JumpInput.Jump -= Jump;
    }

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
        _velocity += _gravity * _gravityScale * Time.deltaTime;
    }

    private void Move()
    {
        _characterController.Move(new Vector3(0, _velocity, 0) * Time.deltaTime);
    }

    public void Jump()
    {
        if (_ground.OnGround.Value)
            _velocity = _jumpHeight;
    }
}