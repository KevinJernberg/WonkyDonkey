using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(PolygonCollider2D))]
public class LineBehavior : MonoBehaviour
{
    private GameObject attatchedGameObject;
    [NonSerialized] public Color normalColor = Color.red;
    [NonSerialized] public Color highLightedColor = Color.white;
    [SerializeField] private Material stringMaterial;
    
    [HideInInspector] public LineRenderer LineRenderer;
    [HideInInspector] public PolygonCollider2D Collider;

    private bool lineComplete;

    
    public bool isSet;

    private Vector2 cent;

    private void Awake()
    {
        LineRenderer = GetComponent<LineRenderer>();
        Collider = GetComponent<PolygonCollider2D>();
        LineRenderer.material = stringMaterial;
        LineRenderer.startColor = normalColor;
        LineRenderer.endColor = normalColor;
    }

    public void SetStartColor()
    {
        LineRenderer.startColor = normalColor;
        LineRenderer.endColor = normalColor;
    }

    private void OnMouseEnter()
    {
        LineRenderer.endColor = highLightedColor;
        LineRenderer.startColor = highLightedColor;
    }

    private void OnMouseExit()
    {
        LineRenderer.endColor = normalColor;
        LineRenderer.startColor = normalColor;
    }

    private void OnMouseDown()
    {
        Debug.Log("DEstroy");
        Destroy(gameObject);
    }

    private void GenerateLineCollider()
    {
        Vector2 startPoint = LineRenderer.GetPosition(0);
        Vector2 endPoint = LineRenderer.GetPosition(LineRenderer.positionCount - 1);

        

        // Update collider position and size
        Vector2 center = (startPoint + endPoint) / 2f;
        float length = Vector2.Distance(startPoint, endPoint);

        Vector2 lineDir = endPoint - startPoint;

        Vector2 lineUpVector = Rotate2DVector(lineDir, (Mathf.PI / 2) - 0.2f).normalized * LineRenderer.startWidth / 2;

        Vector2 toCenterLine = Rotate2DVector(center - startPoint, -0.2f);

        cent = startPoint + lineUpVector + toCenterLine;

        Collider.points = new Vector2[]{
            startPoint + lineUpVector + toCenterLine,
            endPoint + lineUpVector + toCenterLine * 3,
            endPoint + -lineUpVector + toCenterLine * 3,
            startPoint + -lineUpVector + toCenterLine};

    }

    private void Update()
    {
        if (!isSet) return;
        GenerateLineCollider(); 
        
        // Updating line position is done from PersonGuessSpace.cs (i know, i know...) - Olle
    }
    
    public GameObject GetAttachedGameObject()
    {
        return gameObject;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(cent, 0.1f);
    }


    public  Vector2 Rotate2DVector(Vector2 v, float delta) {
        return new Vector2(
            v.x * Mathf.Cos(delta) - v.y * Mathf.Sin(delta),
            v.x * Mathf.Sin(delta) + v.y * Mathf.Cos(delta)
        );
    }
}