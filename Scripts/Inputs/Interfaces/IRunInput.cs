using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRunInput
{
    public event Action RunButtonDown;
    public event Action RunButtonUp;
}