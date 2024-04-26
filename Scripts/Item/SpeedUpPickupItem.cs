using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpPickupItem : MonoBehaviour, IInteractable
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private float _speedUpValue = 0.5f;

    public void Interact()
    {
        _playerMovement.TargetSpeed += _speedUpValue;
        Destroy(gameObject);
    }
}