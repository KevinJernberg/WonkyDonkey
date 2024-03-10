using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogManager : MonoBehaviour
{
    public static CogManager Instance;
    public GameObject trashGame;

    public int correct;
    
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
    
    public void CheckForWin()
    {
        correct++;
        SoundManager.Instance.paperPutDownAction?.Invoke();
        if (correct >= 4)
        {
            transform.parent.GetComponent<LightSwitchPlateAnimationController>().Open();
            trashGame.SetActive(true);
        }
    }
}
