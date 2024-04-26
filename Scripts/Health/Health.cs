using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _max;

    public float Current { get; private set; }

    public event Action<float> ValueChanged;

    public UnityEvent Dead;

    private void Awake()
    {
        Current = _max;
        ValueChanged?.Invoke(Current);
    }

    public void TakeDamage(float value)
    {
        if (Current - value <= 0)
        {
            Current = 0;
            Death();
        }
        else
            Current -= value;

        ValueChanged?.Invoke(Current);
    }

    public void Heal(float value)
    {
        if (Current + value > _max)
            Current = _max;
        else
            Current += value;
        ValueChanged?.Invoke(Current);
    }

    public float GetMax() => _max;

    public virtual void Death()
    {
        Dead?.Invoke();
    }
}