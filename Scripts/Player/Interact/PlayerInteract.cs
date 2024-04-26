using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : Raycaster
{
    [SerializeField] private PlayerInputs _inputs;
    [SerializeField] private AudioSource _audioSource;

    private IInteractable _currentDetectedInteractable;

    public event Action<IInteractable> InteractableDetected;
    public event Action InteractableLost;

    private void OnEnable()
    {
        _inputs.InteractInput.InteractButtonDown += TryInteract;
    }

    private void OnDisable()
    {
        _inputs.InteractInput.InteractButtonDown -= TryInteract;
    }

    private void Update()
    {
        if (CheckColliderHasComponent<IInteractable>(out Collider collider))
        {
            _currentDetectedInteractable = collider.GetComponent<IInteractable>();

            InteractableDetected?.Invoke(_currentDetectedInteractable);
        }
        else
        {
            _currentDetectedInteractable = null;
            InteractableLost?.Invoke();
        }
    }

    public void TryInteract()
    {
        _currentDetectedInteractable?.Interact();
        if (_currentDetectedInteractable != null)
        {
            _audioSource?.Play();
        }
    }
}