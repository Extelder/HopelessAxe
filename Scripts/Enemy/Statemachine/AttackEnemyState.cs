using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.AI;

public class AttackEnemyState : EnemyState
{
    [SerializeField] private EnemyStateMachine _enemyStateMachine;
    [SerializeField] private FollowedObject _followedObject;

    public override void Enter()
    {
        CanChangeState = false;
        EnemyAnimator.Attack();
    }

    public void AttackAnimationEnd()
    {
        CanChangeState = true;
        _enemyStateMachine.Chase();
    }
}