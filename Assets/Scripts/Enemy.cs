using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public Rigidbody2D rb2d;
    public Animator anim;
    public CapsuleCollider2D mainCollider;
    
    public bool moving;

    public bool dead;

    public bool shoot;

    public float enemyHealth = 2.0f;

    public float enemyDamage = 20.0f;

    public float enemyMoveSpeed = 4.0f;

    public CapsuleCollider2D deathCollider;

    // Start is called before the first frame update
    public void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        mainCollider = GetComponent<CapsuleCollider2D>();

        if (deathCollider==null)
        {
            deathCollider = GameObject.Find("EnemyDeathCollider").GetComponent<CapsuleCollider2D>();
        }
    }

    // Update is called once per frame
    public void Update()
    {
        SetAnimations();
    }

    public void SetAnimations()
    {
        anim.SetBool("Shoot", shoot);
        anim.SetBool("Dead", dead);
        anim.SetBool("Moving", moving);
    }

    public void Moving()
    {
        anim.SetBool("Moving", true);
    }

    public void StopMoving()
    {
        anim.SetBool("Moving", false);
        rb2d.velocity = new Vector2(0, 0);
    }

    public void SetDead()
    {
        anim.SetBool("Dead", true);
        dead = true;
        mainCollider.enabled = false;
        deathCollider.enabled = true;
    }

    

}
