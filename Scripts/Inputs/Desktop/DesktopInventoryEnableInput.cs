using System;
using UnityEngine;


public class DesktopInventoryEnableInput : MonoBehaviour, IInventoryEnableInput
{
    public event Action CanvasButtonPressed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            CanvasButtonPressed?.Invoke();
        }
    }
}