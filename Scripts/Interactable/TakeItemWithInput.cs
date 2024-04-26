using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine.Events;

public class TakeItemWithInput : MonoBehaviour, IInteractable
{
    [SerializeField] private float _timeToOneInput;
    [SerializeField] private Transform _positionToTakeItem;
    [SerializeField] private PlayerInputs _playerInputs;
    [SerializeField] private SwitchCamera _switchCamera;
    [SerializeField] private GameObject _interactionCamera;

    private Tween _tween;
    private CancellationTokenSource _cancellationToken = new CancellationTokenSource();

    public UnityEvent TakeEventCompleated;
    
    public void Interact()
    {
        GetComponent<Collider>().enabled = false;

        _switchCamera.SwitchMainCameraTo(_interactionCamera);

        _tween = transform.DOMove(_positionToTakeItem.position, _timeToOneInput).OnComplete(() => { ItemTaked(); });
        _tween.TogglePause();

        _playerInputs.AttackInput.AttackButtonDown += LerpPosition;
    }


    private void OnDisable()
    {
        _playerInputs.AttackInput.AttackButtonDown -= LerpPosition;
        _cancellationToken.Cancel();
    }

    private async void LerpPosition()
    {
        _tween.PlayForward();
        await Task.Delay(TimeSpan.FromSeconds(0.09f), _cancellationToken.Token);
        _tween.PlayBackwards();
    }

    private void ItemTaked()
    {
        _cancellationToken.Cancel();
        _switchCamera.SwitchToMaimCameraFrom(_interactionCamera);

        TakeEventCompleated?.Invoke();
        Destroy(gameObject);
    }
}
