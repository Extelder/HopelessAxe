using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopAimingInput : MonoBehaviour, IAimingInput
{
    [SerializeField] private KeyCode _key;
    public event Action AimButtonDown;
    public event Action AimButtonUp;

    private void Update()
    {
        if (Input.GetKeyDown(_key))
        {
            AimButtonDown?.Invoke();
        }

        if (Input.GetKeyUp(_key))
        {
            AimButtonUp?.Invoke();
        }
    }
}