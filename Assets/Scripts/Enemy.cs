using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public Rigidbody2D rb2d;
    public Animator anim;
    public CapsuleCollider2D mainCollider;

    public GameObject enemyFireBall;
    public Transform enemyShootPosition;
    public float fireballSpeed = 10.0f;

    private bool fireballCreated = false;

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

    public void Attack()
    {
        if (shoot == true)
        {
            shoot = false;
        }
        shoot = true;
        anim.SetBool("Shoot", true);
    }

    public void StopAttack()
    {
        shoot = false;
        anim.SetBool("Shoot", false);
        fireballCreated = true;
    }

    public void CreateFireball()
    {
        if (!fireballCreated)
        {
            GameObject fireBall = Instantiate(enemyFireBall, enemyShootPosition.position, Quaternion.identity) as GameObject;
            fireBall.GetComponent<Rigidbody2D>().AddForce(Vector2.left * fireballSpeed);
            StopAttack();
        }
    }

    public void ReduceHealth()
    {
        enemyHealth -= 1;
    }

    public void CheckDeath()
    {
        if (enemyHealth <= 0)
        {
            SetDead();
        }
    }

}
