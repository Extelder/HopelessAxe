using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractInput 
{
    public event Action InteractButtonDown;
    public event Action InteractButtonUp;
}
