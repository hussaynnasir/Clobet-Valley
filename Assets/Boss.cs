using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{

    public Transform posA, posB, initialPos;

    public bool moveLeft, moveRight, lookLeft, lookRight, stopMoving;

    // Start is called before the first frame update
    new void Start()
    {
        deathCollider.enabled = false;
        rb2d = GetComponentInParent<Rigidbody2D>();
        anim = GetComponentInParent<Animator>();
        mainCollider = GetComponentInParent<CapsuleCollider2D>();

        initialPos = gameObject.transform;

        SetAnimations();
    }

    // Update is called once per frame
    new void Update()
    {
        if (rb2d.velocity.magnitude != 0)
        {
            moving = true;
        }
        if (rb2d.velocity.magnitude == 0)
        {
            moving = false;
        }

        EnemyMover();

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

    private void EnemyMover()
    {
        if (moveLeft)
        {
            if (stopMoving == false)
            {
                MoveLeft();
            }
            if (stopMoving)
            {
                StopEnemy();
            }
        }

        if (moveRight)
        {
            if (stopMoving == false)
            {
                MoveRight();
            }
            if (stopMoving)
            {
                StopEnemy();
            }
        }
    }

    private void MoveLeft()
    {
        if (transform.position.x != posA.position.x)
        {
            moving = true;
            anim.SetBool("Moving", true);
            lookLeft = true;
            rb2d.AddForce(new Vector2(enemyMoveSpeed * -10 * Time.deltaTime, 0));
        }
        if (transform.position.x == posA.position.x)
        {
            stopMoving = true;
        }
    }


    private void MoveRight()
    {
        if (transform.position.x != initialPos.position.x)
        {
            moving = true;
            anim.SetBool("Moving", true);
            lookRight = true;
            rb2d.AddForce(new Vector2(enemyMoveSpeed * 10 * Time.deltaTime, 0));
        }
        if (transform.position.x == initialPos.position.x)
        {
            stopMoving = true;
        }
    }


    private void StopEnemy()
    {
        if (moving == true)
        {
            moveLeft = false;
            moveRight = false;
            rb2d.velocity = new Vector2(0, 0);
            moving = false;
        }
    }


    private void MoveChecker()
    {
        
    }
}
