using DG.Tweening;
using UnityEngine;
using Events;

public class BubbleBehavior : MonoBehaviour
{
    [HideInInspector] const string bubbleTag = "Bubble";

    [SerializeField] private float _currentBubbleSize = 1f;
    [SerializeField] private float mergeTime = 0.5f;

    public float CurrentBubbleSize
    {
        get { return _currentBubbleSize; }
        private set { _currentBubbleSize = value; }
    }

    public BubbleBehavior(float currentBubbleSize)
    {
        this._currentBubbleSize = currentBubbleSize;
    }

    private void Awake()
    {
        SetBubbleSize();
    }

    void SetBubbleSize()
    {
        transform.localScale = Vector3.one * _currentBubbleSize;
    }

    public void MergeWithOtherBubble(float otherBubbleSize)
    {
        if(otherBubbleSize < _currentBubbleSize) 
        { 
            float newBubbleSize = _currentBubbleSize + otherBubbleSize;
            transform.DOScale(newBubbleSize, mergeTime);  
            _currentBubbleSize = newBubbleSize;
            EventManager.Dispatch(BubbleEvents.bubbleMerged, _currentBubbleSize);
        }
        else if(otherBubbleSize > _currentBubbleSize)
        {
            float newBubbleSize = 0;
            transform.DOScale(newBubbleSize, mergeTime).OnComplete(() => DestroyBubble());
        }
        else if(_currentBubbleSize == otherBubbleSize) 
        {
            Debug.Log("Bubbles has an equal size, can't be merged");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == bubbleTag)
        {
            BubbleBehavior otherBubble = collision.transform.GetComponent<BubbleBehavior>();
            MergeWithOtherBubble(otherBubble.CurrentBubbleSize);
            otherBubble.MergeWithOtherBubble(_currentBubbleSize);
        }
    }

    void DestroyBubble()
    {
        //TODO: add VFX  and more
        Destroy(this.gameObject);
    }
}