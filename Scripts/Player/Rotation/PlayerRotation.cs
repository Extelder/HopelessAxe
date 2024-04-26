using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private Transform Camera;

    private void Update()
    {
        transform.eulerAngles =
            new Vector3(transform.eulerAngles.x, Camera.eulerAngles.y, transform.eulerAngles.z);
    }

}