using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    [field: SerializeField] public IMoveAxisInput MoveAxisInput { get; private set; }
    [field: SerializeField] public IRunInput RunInput { get; private set; }
    [field: SerializeField] public IJumpInput JumpInput { get; private set; }
    [field: SerializeField] public IAttackInput AttackInput { get; private set; }
    [field: SerializeField] public IAimingInput AimingInput { get; private set; }
    [field: SerializeField] public IInventoryEnableInput InventoryEnableInput { get; private set; }
    [field: SerializeField] public IInteractInput InteractInput { get; private set; }

    private void Awake()
    {
        MoveAxisInput = GetComponent<IMoveAxisInput>();
        RunInput = GetComponent<IRunInput>();
        JumpInput = GetComponent<IJumpInput>();
        AttackInput = GetComponent<IAttackInput>();
        AimingInput = GetComponent<IAimingInput>();
        InventoryEnableInput = GetComponent<IInventoryEnableInput>();
        InteractInput = GetComponent<IInteractInput>();
    }
}