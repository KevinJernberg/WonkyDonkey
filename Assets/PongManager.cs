using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PongManager : MonoBehaviour
{
    public static PongManager instance;

    public TextMeshProUGUI countText;
    
    public GameObject ball;
    
    public GameObject paddleRight;
    public GameObject paddleLeft;

    public static UnityAction<GameObject> endPong;

    private int bounceCount;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void AddCount()
    {
        bounceCount++;
        countText.text = $"{bounceCount}";

        if (bounceCount >= 10)
        {
            if (ball.transform.position.x > 0)
            {
                endPong?.Invoke(paddleRight);
            }
            else
            {
                endPong?.Invoke(paddleLeft);
            }

            Destroy(ball);
        }
    }
    
}
