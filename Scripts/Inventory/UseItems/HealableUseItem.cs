using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealableUseItem : UseInventoryItem
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private float _healValue;
    
    public override void Use()
    {
        _playerHealth.Heal(_healValue);
        InventoryItem.SpendAmount(1);
    }
}
