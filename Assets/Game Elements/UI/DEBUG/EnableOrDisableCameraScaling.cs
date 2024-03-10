using Events;
using UnityEngine;
using UnityEngine.UI;

public class EnableOrDisableCameraScaling : MonoBehaviour
{
    Toggle toggle;
    private void Awake()
    {
        toggle = GetComponent<Toggle>();
    }
    void Start()
    {
        toggle.onValueChanged.AddListener(SwitchCameraScalingActive);   
    }

    private void SwitchCameraScalingActive(bool arg0)
    {
        EventManager.Dispatch(CameraEvents.switchCameraScalerActive, arg0);
    }
}