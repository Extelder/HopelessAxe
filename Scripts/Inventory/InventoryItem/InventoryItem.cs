using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IPointerDownHandler
{
    [field: SerializeField] public int Amount { get; set; }
    [field: SerializeField] public int SerialNumber { get; set; }

    [field: SerializeField] public Item CurrentItem { get; set; }

    public event Action<Item> CurrentItemChanged;
    public event Action<int> CurrentAmounChanged;
    public event Action Selected;
    public event Action UnSelected;

    public PlayerInventory Inventory { get; set; }

    private UseInventoryItem _useItem;

    private void Start()
    {
        DataChanged();
    }

    public void ChangeCurrentItem(PickupItem item)
    {
        CurrentItem = item.CurrentItem;
        Amount = item.Amount;
        TryFoundUseItem();
        DataChanged();
    }

    public void SpendAmount(int value)
    {
        if (Amount - value <= 0)
            NullifyItemData();
        else
        {
            Amount -= value;
            DataChanged();
        }
    }

    private void NullifyItemData()
    {
        CurrentItem = Inventory.DefaultItem;
        Amount = 0;
        _useItem = null;
        DataChanged();
    }

    private void TryFoundUseItem()
    {
        _useItem = Inventory.FindUseInventoryItem(CurrentItem);
        if (_useItem)
        {
            _useItem?.SetInventoryItem(this);
        }
    }

    public void DataChanged()
    {
        if (CurrentItem != null)
            CurrentItemChanged?.Invoke(CurrentItem);
        CurrentAmounChanged?.Invoke(Amount);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Inventory.SelectedItem == null)
        {
            Inventory.SelectedItem = this;
            TryFoundUseItem();
            Selected?.Invoke();
            return;
        }

        if (Inventory.SelectedItem == this)
        {
            Inventory.SelectedItem = null;
            UnSelected?.Invoke();
            return;
        }

        if (Inventory.SelectedItem != null)
        {
            ChangeItemsDataBetween(Inventory.SelectedItem, this);

            Inventory.SelectedItem.UnSelected?.Invoke();
            UnSelected?.Invoke();
            Inventory.SelectedItem = null;
        }
    }

    private void ChangeItemsDataBetween(InventoryItem item1, InventoryItem item2)
    {
        Item item = item1.CurrentItem;
        int amount = item1.Amount;
        UseInventoryItem useInventoryItem = item1._useItem;

        item1._useItem = item2._useItem;
        item1.CurrentItem = item2.CurrentItem;
        item1.Amount = item2.Amount;

        item2._useItem = useInventoryItem;
        item2.CurrentItem = item;
        item2.Amount = amount;

        item1.DataChanged();
        item2.DataChanged();

        item1.TryFoundUseItem();
        item2.TryFoundUseItem();
    }
}