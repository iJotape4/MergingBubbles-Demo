using UnityEngine;

public class BubbleVFX : MonoBehaviour
{
    BubbleBehavior bubbleBehavior;

    [SerializeField] Animator increasedBubbleVFX;
    [HideInInspector] const string increasedBubbleVFXParam = "TriggerVFXAnimation";

    private void Awake()
    {
        bubbleBehavior = GetComponentInParent<BubbleBehavior>();
        bubbleBehavior.increasedBubble += IncreasedBubbleVFX;
    }

    private void IncreasedBubbleVFX()
    {
        increasedBubbleVFX.SetTrigger(increasedBubbleVFXParam);  
    }

    //Triggered with Animation event
    public void AnimationEnd()
    {
        increasedBubbleVFX.SetBool(increasedBubbleVFXParam, false);
    }
}