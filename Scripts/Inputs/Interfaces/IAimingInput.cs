using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAimingInput
{
    public event Action AimButtonDown;
    public event Action AimButtonUp;
}
