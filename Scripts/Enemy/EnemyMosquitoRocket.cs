using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMosquitoRocket : PoolObject
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FollowedObject _followedObject;
    [SerializeField] private float _rocketForce;
    [SerializeField] private float _rocketDamage;

    private void Update()
    {
        _rigidbody.velocity += transform.forward * _rocketForce * Time.deltaTime;
    }

    private void OnEnable()
    {
        transform.LookAt(_followedObject.transform.position);
    }

    private void OnDisable()
    {
        _rigidbody.velocity = new Vector3(0, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
        {
            playerHealth.TakeDamage(_rocketDamage);
            ReturnToPool();
        }

        if (other.gameObject != this)
            ReturnToPool();
    }
}