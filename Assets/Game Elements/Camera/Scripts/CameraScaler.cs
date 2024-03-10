using Events;
using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraScaler : MonoBehaviour
{
    Camera mainCamera;
    [HideInInspector] float currentCameraSize;
    private const float FOVmultiplier = 5f;
    [SerializeField] float cameraScaleTime = 0.5f;
    private void Awake()
    {
        mainCamera = GetComponent<Camera>();
        currentCameraSize = mainCamera.orthographicSize;
        EventManager.AddListener<float>(BubbleEvents.bubbleMerged, ResizeCamera);
    }

    private void ResizeCamera(float eventData)
    {        
        if ((eventData * FOVmultiplier) < currentCameraSize)
            return; 

        currentCameraSize = eventData * FOVmultiplier;
        mainCamera.DOOrthoSize(currentCameraSize, cameraScaleTime);
    }
}