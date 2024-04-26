using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class PlayerInventoryCanvas : MonoBehaviour 
{
    [SerializeField] private PlayerInputs _inputs;

    private Canvas _canvas;

    public event Action<bool> InventoryCanvasActiveChanged;

    private void Awake()
    {
        _canvas = GetComponent<Canvas>();
    }

    private void OnEnable()
    {
        _inputs.InventoryEnableInput.CanvasButtonPressed += SetInversiveCanvasActive;   
    }

    private void OnDisable()
    {
        _inputs.InventoryEnableInput.CanvasButtonPressed -= SetInversiveCanvasActive;
    }

    private void SetInversiveCanvasActive()
    {
        _canvas.enabled = !_canvas.enabled;
        InventoryCanvasActiveChanged?.Invoke(_canvas.enabled);
    }
}
