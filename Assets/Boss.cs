using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        deathCollider.enabled = false;
        rb2d = GetComponentInParent<Rigidbody2D>();
        anim = GetComponentInParent<Animator>();
        mainCollider = GetComponentInParent<CapsuleCollider2D>();

        SetAnimations();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb2d.velocity.magnitude != 0)
        {
            moving = true;
        }
        if (rb2d.velocity.magnitude == 0)
        {
            moving = false;
        }

        

        CheckDeath();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            if (!dead)
            {
                HealthManager.curHealth -= enemyDamage;
                CodeMonkey.Utils.UtilsClass.ShakeCamera(0.2f, 0.1f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("PlayerFire"))
        {
            ReduceHealth();
        }
    }


}
