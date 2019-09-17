using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{

    public float projectileSpeed = 10f;

    private Rigidbody2D prb2d;
    private SpriteRenderer psprt;

    private bool destroyCheck;

    // Start is called before the first frame update
    void Start()
    {
        prb2d = GetComponent<Rigidbody2D>();
        psprt = GetComponent<SpriteRenderer>();
        destroyCheck = false;

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
    }


}
