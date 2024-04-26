using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopInteractInput : MonoBehaviour, IInteractInput
{
    [field: SerializeField] public KeyCode Key { get; private set; }

    public event Action InteractButtonDown;
    public event Action InteractButtonUp;

    private void Update()
    {
        if (Input.GetKeyDown(Key))
        {
            InteractButtonDown?.Invoke();
        }
        if (Input.GetKeyUp(Key))
        {
            InteractButtonUp?.Invoke();
        }
    }
}
