using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour, IInteractable
{
    [field: SerializeField] public int Amount { get; set; }
    [field: SerializeField] public Item CurrentItem { get; private set; }

    public void Interact()
    {
        PlayerInventory.Instance.ItemPickuped(this);
        Destroy(gameObject);
    }
}
