using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootByRate : MonoBehaviour
{
    [SerializeField] private Pool _bulletPool;
    [SerializeField] private Transform _bulletMuzzle;
    [SerializeField] private float _minBulletRate;
    [SerializeField] private float _maxBulletRate;

    private void OnEnable()
    {
        StartCoroutine(Shooting());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator Shooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(_minBulletRate, _maxBulletRate));
            _bulletPool.GetFreeElement(_bulletMuzzle.position);
        }
    }
}