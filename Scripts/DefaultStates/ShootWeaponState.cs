using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class ShootWeaponState : WeaponState
{
    [SerializeField] private Transform _camera;
    [SerializeField] private LayerMask _attackLayerMask;
    [SerializeField] private CinemachineImpulseSource _attackShake;
    [SerializeField] private Pool _bloodHitParticlePool;
    [SerializeField] private Pool _decalParticlePool;

    public float AttackDamage = 24;
    public float AttackRange = 2.3f;

    public override void Enter()
    {
        CanChangeState = false;
        WeaponAnimator.Shoot();
    }

    public void AnimationStateEnded()
    {
        CanChangeState = true;
    }

    public void PerformShoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(_camera.position, _camera.forward, out hit, AttackRange, _attackLayerMask))
        {
            if (hit.collider == null)
                return;
            _attackShake.GenerateImpulse();

            if (hit.collider.TryGetComponent<EnemyHeadHitBox>(out EnemyHeadHitBox hitBox))
            {
                _bloodHitParticlePool.GetFreeElement(hit.point, Quaternion.identity);
                hitBox.Hit(AttackDamage);
                return;
            }

            if (hit.collider.TryGetComponent<Health>(out Health health))
            {
                _bloodHitParticlePool.GetFreeElement(hit.point, Quaternion.identity);
                health.TakeDamage(AttackDamage);
                return;
            }

            ReturnDecal(hit);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(_camera.position, _camera.forward * AttackRange);
    }

    private void ReturnDecal(RaycastHit hit)
    {
        PoolObject poolObject = _decalParticlePool.GetFreeElement(hit.point, Quaternion.identity);
        poolObject.transform.rotation = Quaternion.FromToRotation(poolObject.transform.up, hit.normal);
    }
}