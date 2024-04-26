using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemUI : MonoBehaviour
{
    [SerializeField] private GameObject _selectedOutline;
    [SerializeField] private Text _amountText;
    [SerializeField] private Image _icon;

    [SerializeField] private InventoryItem _inventoryItem;
    
    private void OnEnable()
    {
        _inventoryItem.CurrentAmounChanged += OnCurrentAmountChanged;
        _inventoryItem.CurrentItemChanged += OnCurrentItemChanged;
        _inventoryItem.Selected += OnItemSelected;
        _inventoryItem.UnSelected += OnItemUnSelected;
    }

    private void OnDisable()
    {
        _inventoryItem.CurrentAmounChanged -= OnCurrentAmountChanged;
        _inventoryItem.CurrentItemChanged -= OnCurrentItemChanged;
        _inventoryItem.Selected -= OnItemSelected;
        _inventoryItem.UnSelected -= OnItemUnSelected;
    }

    private void OnCurrentAmountChanged(int amount)
    {
        if(amount == 0)
        {
            _amountText.text = "";
            return;
        }
        _amountText.text = amount.ToString();
    }

    private void OnCurrentItemChanged(Item item)
    {
        _icon.sprite = item.Icon;
    }

    private void OnItemSelected()
    {
        _selectedOutline.SetActive(true);
    }
    private void OnItemUnSelected()
    {
        _selectedOutline.SetActive(false);
    }
}
