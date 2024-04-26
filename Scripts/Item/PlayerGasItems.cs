using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerGasItems : MonoBehaviour
{
    private int _pickupedGas = 0;

    public UnityEvent OnAllGasesPickuped;

    public void GasItemPickuped()
    {
        _pickupedGas++;
        if (_pickupedGas == 3)
        {
            OnAllGasesPickuped.Invoke();
        }
    }
}