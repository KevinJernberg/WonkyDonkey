using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DinoManager : MonoBehaviour
{
    
    public static DinoManager Instance;
    public GameObject trashGame;

    public SpriteRenderer coin1;
    public SpriteRenderer coin2;

    public Sprite fullCoin;

    public static UnityAction stopgame;

    public int coins;
    
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


    public void AddCoin(GameObject coinobj)
    {
        coins++;
        if (coins >= 3)
        {
            stopgame?.Invoke();
            Physics2D.gravity = new Vector2(0f, -9.81f);
        }
        else if (coins >= 2)
        {
            Destroy(coinobj);
            coin2.sprite = fullCoin;
        }
        else if (coins >= 1)
        {
            Destroy(coinobj);
            coin1.sprite = fullCoin;
        }
    }
}
