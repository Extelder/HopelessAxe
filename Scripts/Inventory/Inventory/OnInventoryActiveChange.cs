using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnInventoryActiveChange : MonoBehaviour
{
    [SerializeField] private PlayerInventoryCanvas _playerInventoryCanvas;
    [SerializeField] private GameCursor _gameCursor;

    private void OnEnable()
    {
        _playerInventoryCanvas.InventoryCanvasActiveChanged += OnInventoryActiveChanged;
    }

    private void OnDisable()
    {
        _playerInventoryCanvas.InventoryCanvasActiveChanged -= OnInventoryActiveChanged;
    }

    private void OnInventoryActiveChanged(bool canvasActive)
    {
        if (canvasActive)
        {
            _gameCursor.Enable();
            MainCinemachineCamera.Instance.SetZeroSensetivity();
        }
        else
        {
            _gameCursor.Disable();
            MainCinemachineCamera.Instance.SetDefaultSensetivity();
        }
    }
}
