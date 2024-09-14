using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScaleOnHover : MonoBehaviour
{
    [SerializeField, Tooltip("Distance the object moves when hovered on."), Range(1f, 2f)] 
    private float hoverScale = 1f;
    
    private Vector3 _originalScale;
    private Transform _transform;

    public UnityEvent clickEvent;
    public bool clicked;

    private void Awake()
    {
        _originalScale = transform.localScale;
        _transform = GetComponent<Transform>();
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    private void OnMouseEnter()
    {
        _transform.localScale = Vector3.one * hoverScale;
    }

    private void OnMouseExit()
    {
        _transform.localScale =  _originalScale;
    }

    private void OnMouseDown()
    {
        if (clicked) return;
        clicked = true;
        clickEvent?.Invoke();
        SoundManager.Instance.SolvedRiddleAction?.Invoke();
    }
}