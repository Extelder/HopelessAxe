using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UseInventoryItem : MonoBehaviour
{
    [SerializeField] private Button _button;
    public InventoryItem InventoryItem { get; private set; }

    [field: SerializeField] public Item CurrentItem { get; private set; }

    public void SetInventoryItem(InventoryItem item)
    {
        UnSubscribe();
        InventoryItem = item;
        Subscribe();
    }

    private void OnDisable()
    {
        UnSubscribe();
    }

    public abstract void Use();

    public virtual void UnUse() { }

    public void EnableUseButton()
    {
        _button.gameObject.SetActive(true);
        _button.onClick?.AddListener(Use);
    }

    public void DisableUseButton()
    {
        _button.gameObject.SetActive(false);
        _button.onClick?.RemoveListener(Use);
    }

    private void UnSubscribe()
    {
        if (InventoryItem != null)
        {
            InventoryItem.Selected -= EnableUseButton;
            InventoryItem.UnSelected -= DisableUseButton;
        }
    }

    private void Subscribe()
    {
        if (InventoryItem != null)
        {
            InventoryItem.Selected += EnableUseButton;
            InventoryItem.UnSelected += DisableUseButton;
        }
    }
}