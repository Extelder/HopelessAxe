using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField] private string _helpString;
    [SerializeField] private Text _helpText;
    [SerializeField] private PlayerInteract _playerInteract;


    private void OnEnable()
    {
        _playerInteract.InteractableDetected += OnInteractDetected;
        _playerInteract.InteractableLost += OnInteractLost;
    }

    private void OnDisable()
    {
        _playerInteract.InteractableDetected -= OnInteractDetected;
        _playerInteract.InteractableLost -= OnInteractLost;
    }

    private void OnInteractDetected(IInteractable interactable)
    {
        _helpText.text = _helpString;
    }

    private void OnInteractLost()
    {
        _helpText.text = "";
    }
}
