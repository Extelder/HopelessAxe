using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopRunInput : MonoBehaviour, IRunInput
{
    [SerializeField] public KeyCode Key = KeyCode.LeftShift;
    public event Action RunButtonDown;
    public event Action RunButtonUp;

    private void Update()
    {
        if (Input.GetKeyDown(Key))
        {
            RunButtonDown?.Invoke();
        }

        else if (Input.GetKeyUp(Key))
        {
            RunButtonUp?.Invoke();
        }
    }
}