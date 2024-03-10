using UnityEngine;

public class BubbleVFX : MonoBehaviour
{
    BubbleBehavior bubbleBehavior;
    SpriteRenderer spriteRenderer;

    [SerializeField] Sprite annexedBubbleVFX;
    [SerializeField] GameObject increasedBubbleVFX;

    private void Awake()
    {
        bubbleBehavior = GetComponent<BubbleBehavior>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        bubbleBehavior.annexedBubble += AnnexedBubbleVFX;
    }

    private void AnnexedBubbleVFX()
    {
        spriteRenderer.sprite = annexedBubbleVFX;
    }
}
