using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ActivateRandomEnemySkinOnActivate : MonoBehaviour
{
    [SerializeField] private GameObject[] _skines;

    private void OnEnable()
    {
        _skines[Random.Range(0, _skines.Length)].SetActive(true);
    }
}