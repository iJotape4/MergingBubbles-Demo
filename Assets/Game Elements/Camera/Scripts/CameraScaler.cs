using Events;
using DG.Tweening;
using UnityEngine;

public class CameraScaler : MonoBehaviour
{
    Camera mainCamera;
    [HideInInspector] float currentCameraSize;
    private const float FOVmultiplier = 5f;
    [SerializeField] float cameraScaleTime = 0.5f;

    bool scalingEnabled = true;

    private void Awake()
    {
        mainCamera = GetComponent<Camera>();
        currentCameraSize = mainCamera.orthographicSize;
        EventManager.AddListener<float>(BubbleEvents.bubbleMerged, ResizeCamera);
        EventManager.AddListener<bool>(CameraEvents.switchCameraScalerActive, SwitchCameraScalingEnable);
    }

    private void ResizeCamera(float eventData)
    {        
        if(!scalingEnabled) 
            return;

        if ((eventData * FOVmultiplier) < currentCameraSize)
            return; 

        currentCameraSize = eventData * FOVmultiplier;
        mainCamera.DOOrthoSize(currentCameraSize, cameraScaleTime);
    }

    private void SwitchCameraScalingEnable(bool enable)
    {
        scalingEnabled = enable;
    }
}