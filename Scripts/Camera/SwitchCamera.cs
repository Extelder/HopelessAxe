using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    [SerializeField] private GameObject _mainCamera;

    public void SwitchMainCameraTo(GameObject camera)
    {
        _mainCamera.SetActive(false);
        camera.SetActive(true);
    }

    public void SwitchToMaimCameraFrom(GameObject camera)
    {
        _mainCamera.SetActive(true);
        camera.SetActive(false);
    }
}
