using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{

    public float projectileSpeed = 10f;

    private Rigidbody2D prb2d;
    private SpriteRenderer psprt;
    

    public AudioManager audioManager;

    private bool destroyCheck;

    // Start is called before the first frame update
    void Start()
    {
        prb2d = GetComponent<Rigidbody2D>();
        psprt = GetComponent<SpriteRenderer>();
        destroyCheck = false;
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        audioManager.PlayFireLeave();


        if (PlayerController.LookRight==true)
        { 
            prb2d.velocity = new Vector2(projectileSpeed, 0);
            psprt.flipX = true;
        }
        if (PlayerController.LookRight==false)
        {
            prb2d.velocity = new Vector2(-projectileSpeed, 0);
            psprt.flipX = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("OutsideFrame"))
        {
            Destroy(gameObject);
        }

        if (collision.tag.Equals("Bubble"))
        {
            BubbleShooter.bubbleHitCounter += 1;
            if (BubbleShooter.bubbleHitCounter <= 4) 
            {
                audioManager.PlayFireHit();
                collision.gameObject.SetActive(false);
                gameObject.SetActive(false);
                CodeMonkey.Utils.UtilsClass.ShakeCamera(0.2f, 0.1f);
                //    Debug.Log("Bubble Counter is: " + BubbleShooter.bubbleHitCounter);
            }
        }

        if (collision.tag.Equals("Enemy"))
        {
            audioManager.PlayFireHit();
            gameObject.SetActive(false);
            CodeMonkey.Utils.UtilsClass.ShakeCamera(0.2f, 0.1f);
        }
    }


}
