using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Image _bar;

    private void OnEnable()
    {
        _health.ValueChanged += OnHealthValueChanged;
    }

    private void OnDisable()
    {
        _health.ValueChanged -= OnHealthValueChanged;
    }

    private void OnHealthValueChanged(float value)
    {
        if (value == 0)
        {
            _bar.fillAmount = 0;
            return;
        }

        float healthProcent = (value * 100) / _health.GetMax();
        float normalizedProcent = healthProcent / 100;

        Debug.Log(normalizedProcent);
        _bar.fillAmount = normalizedProcent;
    }
}