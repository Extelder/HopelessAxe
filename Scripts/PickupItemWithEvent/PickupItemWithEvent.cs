using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickupItemWithEvent : MonoBehaviour, IInteractable
{
    [SerializeField] private bool _destroyAfterPickup = true;

    public UnityEvent Event;
    public bool Blocked = false;

    public void Interact()
    {
        if (Blocked)
            return;
        Event?.Invoke();
        if (_destroyAfterPickup)
            Destroy(gameObject);
    }
}