using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragLines : MonoBehaviour
{
    [SerializeField] private List<LineBehavior> lines;
    [SerializeField] private GameObject linePrefab;
    
    [SerializeField] private Color normalColor = Color.red;
    [SerializeField] private Color highLightedColor = Color.white;
    
    private LineBehavior _currentLine;
        
    private const int LINEVERTECIES = 2;
    
    
    private void OnMouseDown()
    {
        var newLine = Instantiate(linePrefab, transform);
        _currentLine = newLine.GetComponent<LineBehavior>();
        _currentLine.normalColor = normalColor;
        _currentLine.highLightedColor = highLightedColor;
        _currentLine.SetStartColor();
        _currentLine.LineRenderer.SetPosition(0, transform.position);
        _currentLine.LineRenderer.positionCount = LINEVERTECIES;

    }

    private void OnMouseDrag()
    {
        _currentLine.LineRenderer.SetPosition(LINEVERTECIES - 1, MouseWorldPosition());
    }

    private void OnMouseUp()
    {
        Vector3 rayOrigin = Camera.main.transform.position;
        Vector3 rayDirection =  Camera.main.transform.position - Camera.main.ScreenToWorldPoint(transform.position);

        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, rayDirection);
        
        if (hit.transform.CompareTag("Circuit"))
        {
            _currentLine.isSet = true;
            AddLine(hit.transform.gameObject);
        }
        else
        {
            Destroy(_currentLine.gameObject);
        }
    }
    
    private Vector3 MouseWorldPosition()
    {
        Vector3 mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
    
    private void AddLine(GameObject attachedObject)
    {
        _currentLine.GetAttachedGameObject();
        lines.Add(_currentLine);
    }
}
