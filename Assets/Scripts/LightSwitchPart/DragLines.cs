using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragLines : MonoBehaviour
{
    [SerializeField] private GameObject linePrefab;
    [SerializeField] private GameObject asteriskPrefab;
    
    [SerializeField] public Color normalColor = Color.red;
    [SerializeField] public Color highLightedColor = Color.white;
    
    public LineBehavior currentLine;
    private static GameObject asterisk;

    [SerializeField] public CircuitColor lineColor;

    public bool isLined;
    
    private void OnMouseDown()
    {
        if (!isLined)
        {
            if (LineManager.Instance.beginning == null)
            {
                if (LineManager.Instance.beginning == this) return;
                if (asterisk != null)
                    RemoveAsterisk();
                asterisk = Instantiate(asteriskPrefab, transform);
                LineManager.Instance.beginning = this;
                LineManager.Instance.StartLine();
            }
            else
            {
                LineManager.Instance.end = this;
                LineManager.Instance.DrawLine();
            }
        }
        else
        {
            isLined = false;
            if (LineManager.Instance.beginning == this)
            {
                if (asterisk != null)
                    RemoveAsterisk();
            }
            LineManager.Instance.beginning = null;
            if (currentLine == null) return;
            currentLine.RemoveLine();
            currentLine = null;
            LineManager.Instance.CheckForDone();
        }
    }

    private void OnMouseEnter()
    {
        if (currentLine == null) return;
        currentLine.LineRenderer.startColor = currentLine.startGameObject.highLightedColor;
        currentLine.LineRenderer.endColor = currentLine.startGameObject.highLightedColor;
    }

    private void OnMouseExit()
    {
        if (currentLine == null) return;
        currentLine.LineRenderer.startColor = currentLine.startGameObject.normalColor;
        currentLine.LineRenderer.endColor = currentLine.startGameObject.normalColor;
    }


    public void AddLine(LineBehavior attachedObject)
    {
        currentLine = attachedObject;
    }

    public void RemoveAsterisk()
    {
        Destroy(asterisk);
        asterisk = null;
    }
}
