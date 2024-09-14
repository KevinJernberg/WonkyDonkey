using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBugMovement : MonoBehaviour
{
    public EnemyBugSight sight;
    public Animator anim;
    public Rigidbody rb;

    public float enemySpeed;
    public bool isHit;
    public float timer = 2;
    public bool boss;

    private void Update()
    {
        if (sight.seesPlayer)
        {
            anim.enabled = true;
            rb.velocity =
                Vector3.ProjectOnPlane(
                    ThirdDPlayerController.Instance.transform.position - transform.position, Vector3.up).normalized * enemySpeed;
        }
        else
        {
            anim.enabled = false;
        }

        if (isHit)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                if (boss)
                {
                    MusicManager.Instance.StopFliesMusic();
                    MusicManager.Instance.StopFart();
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    Destroy(this.gameObject);
                }

                Destroy(this.gameObject);

            }
        }
    }
}
