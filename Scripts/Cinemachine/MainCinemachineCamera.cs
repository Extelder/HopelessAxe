using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class MainCinemachineCamera : MonoBehaviour
{
    private CinemachineVirtualCamera _cinemachineVirtualCamera;
    private CinemachinePOV _cinemachinePOV;
    private Vector2 _defaultSensetivity;

    public static MainCinemachineCamera Instance { get; private set; }

    private void Awake()
    {
        _cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        _cinemachinePOV = _cinemachineVirtualCamera.GetCinemachineComponent<CinemachinePOV>();
        _defaultSensetivity = new Vector2(_cinemachinePOV.m_HorizontalAxis.m_MaxSpeed, _cinemachinePOV.m_VerticalAxis.m_MaxSpeed);
    
        if(Instance == null)
        { 
            Instance = this;
            return;
        } 
        Destroy(gameObject);
    }

    public void SetSensetivity(float horizontalValue, float verticalValue)
    {
        _cinemachinePOV.m_HorizontalAxis.m_MaxSpeed = horizontalValue;
        _cinemachinePOV.m_VerticalAxis.m_MaxSpeed = verticalValue;
    }

    public void SetDefaultSensetivity()
    {
        SetSensetivity(_defaultSensetivity.x, _defaultSensetivity.y);
    }

    public void SetZeroSensetivity()
    {
        SetSensetivity(0, 0);
    }
}
