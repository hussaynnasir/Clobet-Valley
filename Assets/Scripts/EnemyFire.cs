using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
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


        
        prb2d.velocity = new Vector2(-projectileSpeed, 0);
        
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



        if (collision.tag.Equals("Player"))
        {
            if (!PlayerController.hide)
            {
                audioManager.PlayFireHit();
                HealthManager.curHealth -= 20;
                gameObject.SetActive(false);
                CodeMonkey.Utils.UtilsClass.ShakeCamera(0.2f, 0.1f);
            }
        }
    }


}
