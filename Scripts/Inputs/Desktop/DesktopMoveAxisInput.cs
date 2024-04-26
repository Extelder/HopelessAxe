using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopMoveAxisInput : MonoBehaviour, IMoveAxisInput
{
    public Vector2 InputAxis { get; set; }

    private void Update()
    {
        InputAxis = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

}
