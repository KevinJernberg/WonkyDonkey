using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class File : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Image thisImage;
    public Vector3 startPosition;
    private void Start()
    {
        thisImage = GetComponent<Image>();
        startPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0.5f);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        SoundManager.Instance.PaperPickUpAction?.Invoke();
        thisImage.raycastTarget = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        SoundManager.Instance.paperPutDownAction?.Invoke();
        transform.position = startPosition;
        thisImage.raycastTarget = true;
    }
}