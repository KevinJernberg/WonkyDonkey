using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CircuitColor
{
    Green,
    Blue,
    Red
}
    
    
public class LightSwitch : MonoBehaviour
{
    private bool isOn;

    private int clickAmount;
    [SerializeField] private GameObject circuitPart;
    private SpriteRenderer spriteRenderer;
    
    [SerializeField]
    private Sprite onSprite;
    [SerializeField]
    private Sprite offSprite;
    
    [SerializeField]
    private Transform onTransform;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        SoundManager.Instance.LightFlickAction?.Invoke();
        clickAmount++;
        isOn = !isOn;
        spriteRenderer.sprite = isOn ? onSprite : offSprite;

        onTransform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
        if (clickAmount >= 10)
        {
            EnableCircuitPart();
            transform.parent.GetComponent<LightSwitchPlateAnimationController>().Open();
        }
    }


    private void EnableCircuitPart()
    {
        circuitPart.SetActive(true);
    }
}
