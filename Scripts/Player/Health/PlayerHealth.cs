using System;
using UnityEngine;


public class PlayerHealth : Health
{
    private void Start()
    {
        TakeDamage(20f);
    }

    public override void Death()
    {
        base.Death();
        Debug.Log("Something");
    }
}