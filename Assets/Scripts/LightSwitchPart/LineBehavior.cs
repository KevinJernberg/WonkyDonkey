using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineBehavior : MonoBehaviour
{
    public DragLines startGameObject;
    public DragLines endGameObject;
    [NonSerialized] public Color normalColor = Color.red;
    [NonSerialized] public Color highLightedColor = Color.white;
    [SerializeField] private Material stringMaterial;
    
    [HideInInspector] public LineRenderer LineRenderer;
    [HideInInspector] public PolygonCollider2D Collider;

    private bool lineComplete;
    

    private Vector2 cent;

    private void Awake()
    {
        LineRenderer = GetComponent<LineRenderer>();
        LineRenderer.material = stringMaterial;
    }

    public void SetLine()
    {
        LineRenderer.startColor = normalColor;
        LineRenderer.endColor = normalColor;
        
        LineRenderer.SetPosition(0, startGameObject.transform.position);
        LineRenderer.SetPosition(1, endGameObject.transform.position);
        
        
    }

    public GameObject GetAttachedGameObjects()
    {
        return gameObject;
    }

    public void RemoveLine()
    {
        startGameObject.isLined = false;
        endGameObject.isLined = false;
        
        startGameObject.currentLine = null;
        endGameObject.currentLine = null;
        
        Destroy(this.gameObject);
    }
}