using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObjectOnKeyCode : MonoBehaviour
{
    [SerializeField] private KeyCode _keyCode;

    private void Update()
    {
        if (Input.GetKeyDown(_keyCode))
        {
            gameObject.SetActive(false);
        }
    }
}