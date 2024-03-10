using System;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider2D))]  // A collider is required to identify the drag
public class DragView : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public event Action<PointerEventData> OnDragBegan;
    public event Action<PointerEventData> OnDragEnded;

    private new Collider2D collider;
    private Camera mainCamera;

    private Vector3 currentDragPosition;

    bool isDragging, draggingAllowed = true;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log($"OnBeginDrag {eventData.position}", gameObject);
        if (!draggingAllowed) return;
        isDragging = true;
        OnDragBegan?.Invoke(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!draggingAllowed)
        {
            if (isDragging)               
                OnEndDrag(eventData);
                
            eventData.pointerDrag = null;
            return;
        }
        //Debug.Log($"OnDrag {eventData.position}", gameObject);
           
        currentDragPosition = mainCamera.ScreenToWorldPoint(eventData.position);
        currentDragPosition.z = transform.position.z;
        transform.position = currentDragPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnDragEnded?.Invoke(eventData);
    }
}