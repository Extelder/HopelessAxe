using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObjectActive : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;

    public void SetActive(bool value)
    {
        _gameObject.SetActive(value);
    }
}
