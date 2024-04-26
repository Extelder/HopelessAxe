using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPickupItem : MonoBehaviour, IInteractable
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private float _healValue;

    public void Interact()
    {
        _playerHealth.Heal(_healValue);
        Destroy(gameObject);
    }
}