using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    public static LineManager Instance;

    public DragLines beginning;
    public DragLines end;

    [SerializeField] private GameObject linePrefab;
    [SerializeField] private GameObject cogsSection;
    [SerializeField] private LineBehavior line;

    private const int LINEVERTECIES = 2;

    private int correctAmount = 0;

    public List<LineBehavior> lines;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void DrawLine()
    {
        beginning.isLined = true;
        end.isLined = true;
        
        if (line == null)
            StartLine();

        line.startGameObject = beginning;
        line.endGameObject = end;
        
        line.startGameObject.RemoveAsterisk();

        beginning.AddLine(line);
        end.AddLine(line);

        beginning = null;
        end = null;

        line.SetLine();
    }

    public void StartLine()
    {
        var newLine = Instantiate(linePrefab, transform);
        line = newLine.GetComponent<LineBehavior>();

        line.normalColor = beginning.normalColor;
        line.highLightedColor = beginning.highLightedColor;
    }

    public void CheckForDone()
    {
        int amountCorrect = 0;
        foreach (var currentLine in lines)
        {
            if (currentLine.lineCorrect)
            {
                amountCorrect++;
            }
            else
            {
                amountCorrect--;
            }
        }
        Debug.Log(amountCorrect);

        if (amountCorrect >= 3)
        {
            transform.parent.GetComponent<LightSwitchPlateAnimationController>().Open();
            cogsSection.SetActive(true);
            foreach (var currentLine in lines)
            {
                Destroy(currentLine.gameObject);
            }
        }
    }

}
