using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [field: SerializeField] public Item DefaultItem { get; private set; }
    
    [field: SerializeField] public List<InventoryItem> Items { get; private set; }
    [field: SerializeField] public List<UseInventoryItem> UseItems { get; private set; }

    public InventoryItem SelectedItem { get; set; }
    public UseInventoryItem CurrentUseInventoryItem { get; set; }
    public static PlayerInventory Instance { get; private set; }


    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < Items.ToArray().Length; i++)
        {
            Items[i].SerialNumber = i + 1;
            Items[i].Inventory = this;
        }
    }

    public void UpdateAllSlotsData()
    {
        foreach (InventoryItem item in Items)
        {
            if(item.CurrentItem != DefaultItem)
            {
                item.DataChanged();
            }
        }
    }

    public UseInventoryItem FindUseInventoryItem(Item item)
    {
        foreach (UseInventoryItem useInventoryItem in UseItems)
        {
            if (useInventoryItem.CurrentItem == item)
            {
                return useInventoryItem;
            }
        }

        return null;
    }
    
    public void ItemPickuped(PickupItem item)
    {
        foreach (InventoryItem inventoryItem in Items)
        {
            if (inventoryItem.CurrentItem == item.CurrentItem)
            {
                if((inventoryItem.Amount + item.Amount) > inventoryItem.CurrentItem.MaxAmount)
                {
                    int delta = inventoryItem.CurrentItem.MaxAmount - inventoryItem.Amount;
                    inventoryItem.Amount += delta;
                    item.Amount -= delta;
                    inventoryItem.DataChanged();
                    Debug.Log("Items summ bigger than maxamount");
                    Debug.Log(delta);
                }
                if((inventoryItem.Amount + item.Amount) <= inventoryItem.CurrentItem.MaxAmount)
                {
                    inventoryItem.Amount += item.Amount;
                    inventoryItem.DataChanged();
                    Debug.Log("Item summ lesser than maxamiunt");
                    return;
                }
            }   
        }
        foreach (InventoryItem inventoryItem in Items)
        {
            if(inventoryItem.CurrentItem == DefaultItem)
            {
                inventoryItem.ChangeCurrentItem(item);
                return;
            }
        }
    }
}
