using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdDPlayerController : MonoBehaviour
{
    public static ThirdDPlayerController Instance;
    
    public CharacterController controller;

    public float speed = 12;
    private Vector3 moveVector;

    private Animator anim;
    
    private bool canShoot;
    
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

    private void Start()
    {
        MusicManager.Instance.StopDoodleMusic();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        moveVector = transform.right * (Input.GetAxis("Horizontal")) + transform.forward * Input.GetAxis("Vertical");

        
        
        controller.Move(moveVector * speed * Time.deltaTime);

        if (Input.GetMouseButton(0))
        { 
            
            if (canShoot)
            {
                Debug.Log("Down");
                MusicManager.Instance.PlayFart();
                canShoot = false;
            }
            
            anim.SetBool("LighterIsOn", true);
        }
        
        else
        {
            Debug.Log("Up");
            MusicManager.Instance.StopFart();
            anim.SetBool("LighterIsOn", false);
            canShoot = true;
        }
       
    }
    
    
}
