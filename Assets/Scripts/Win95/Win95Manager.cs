using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win95Manager : MonoBehaviour
{
    public static Win95Manager Instance;
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
    
    public void CheckForWin(bool isSystem32)
    {
        correct++;
        SoundManager.Instance.PaperBinAction?.Invoke();
        if (!isSystem32)
        {
            if (correct >= 20)
            {
                SoundManager.Instance.SolvedRiddleActionShort?.Invoke();
                transform.parent.GetComponent<LightSwitchPlateAnimationController>().Open();
                trashGame.SetActive(true);
            }
        }
        else
        {
            Application.Quit();
        }   
    }
}