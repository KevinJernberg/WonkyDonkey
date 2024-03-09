using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win95Manager : MonoBehaviour
{
    public static Win95Manager Instance;

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
        if (!isSystem32)
        {
            if (correct >= 20)
            {
                transform.parent.GetComponent<LightSwitchPlateAnimationController>().Open();
            }
        }
        else
        {
            Debug.Log("System32 Deleted");
        }   
    }
}