using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private DayAndNightControl _dayAndNightControl;
    [SerializeField] private GameObject _enemyPrefab;

    private CompositeDisposable _disposable = new CompositeDisposable();

    private bool _spawned;

    private void OnEnable()
    {
        _dayAndNightControl.currentTime.Subscribe(_ =>
        {
            if (_ > 0.8f && _ < 1f && !_spawned)
            {
                OnNightStared();
            }
        }).AddTo(_disposable);
    }

    private void OnDisable()
    {
        _disposable.Clear();
    }

    private void OnNightStared()
    {
        GameObject enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
        enemy.SetActive(true);
        _spawned = true;
        Observable.Timer(TimeSpan.FromSeconds(5f)).Subscribe(_ => { _spawned = false; }).AddTo(_disposable);
        transform.position = new Vector3(transform.position.x - Random.Range(-7, 7f), transform.position.y,
            transform.position.z - Random.Range(-7, 7f));
    }
}