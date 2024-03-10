using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class SoundPickUp : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Image thisImage;
    
    void Start()
    {
        thisImage = GetComponent<Image>();
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        SoundManager.Instance.PaperPickUpAction?.Invoke();
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Draging)");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Pick Down");
        SoundManager.Instance.paperPutDownAction?.Invoke();
    }
}
