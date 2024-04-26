using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterTime : MonoBehaviour
{
    [SerializeField] private float _timeInSeconds = 10f;

    private void OnEnable()
    {
        Invoke(nameof(Disable), _timeInSeconds);
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }
}