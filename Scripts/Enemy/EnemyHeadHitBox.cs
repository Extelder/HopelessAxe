using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeadHitBox : MonoBehaviour
{
    [SerializeField] private Health _enemyHealth;
    [SerializeField] private float _damageMultiply = 1.2f;

    public void Hit(float damage)
    {
        _enemyHealth.TakeDamage(damage * _damageMultiply);
    }
}