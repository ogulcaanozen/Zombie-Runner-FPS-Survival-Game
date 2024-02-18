using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using Cinemachine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera fpsCamera;
    [SerializeField] FirstPersonController fpsController;
    [SerializeField] float zoomedOutFOV = 40f;
    [SerializeField] float zoomedInFOV = 20f;
    [SerializeField] float zoomOutSensitivity = 2f;
    [SerializeField] float zoomInSensitivity = .5f;

    // FOV değerini değiştirmek için LensSettings türünden bir nesne oluşturuyoruz
    LensSettings lensSettings;

    bool zoomedInToggle = false;

    private void OnDisable()
    {
        ZoomOut();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            lensSettings = fpsCamera.m_Lens;
            if (zoomedInToggle == false)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }

            // Değiştirilmiş LensSettings'i CinemachineVirtualCamera bileşenine atıyoruz
            fpsCamera.m_Lens = lensSettings;
        }
    }

    private void ZoomIn()
    {
        zoomedInToggle = true;
        lensSettings.FieldOfView = zoomedInFOV;
        fpsController.RotationSpeed = zoomInSensitivity;
    }

    private void ZoomOut()
    {
        zoomedInToggle = false;
        lensSettings.FieldOfView = zoomedOutFOV;
        fpsController.RotationSpeed = zoomOutSensitivity;
    }
}
