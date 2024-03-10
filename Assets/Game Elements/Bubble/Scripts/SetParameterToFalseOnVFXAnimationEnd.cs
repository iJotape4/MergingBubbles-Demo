using UnityEngine;
public class SetParameterToFalseOnVFXAnimationEnd : MonoBehaviour
{
    public void DisableObject()
    {
        this.gameObject.SetActive(false);
    }
}