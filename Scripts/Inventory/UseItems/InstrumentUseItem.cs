using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentUseItem : UseInventoryItem
{
    [SerializeField] private GameObject _gameObject;

    public override void Use()
    {
        PlayerInventory.Instance.CurrentUseInventoryItem?.UnUse();
        _gameObject.SetActive(true);
        PlayerInventory.Instance.CurrentUseInventoryItem = this;
    }

    public override void UnUse()
    {
        _gameObject.SetActive(false);
    }
}