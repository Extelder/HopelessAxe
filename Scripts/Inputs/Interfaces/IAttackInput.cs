using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackInput
{
    public event Action AttackButtonDown;
    public event Action AttackButtonUp;
}
