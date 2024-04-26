using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPickupItem : MonoBehaviour, IInteractable
{
    [SerializeField] private ShootWeaponState _shootWeaponState;
    [SerializeField] private float _damageUpValue = 10f;

    public void Interact()
    {
        _shootWeaponState.AttackDamage += _damageUpValue;
        Destroy(gameObject);
    }
}