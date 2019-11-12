using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Professor : Enemy
{
    private Vector3 moveDirection;

    public float horizontalSpeedCheckLow = -4.0f, horizontalSpeedCheckHigh = 4.0f;
    public float horizontalMoveSpeed;
    public bool zameenNaalTakrao;
    private bool runCouroutineOnce;

    // Start is called before the first frame update
    private new void Start()
    {
        deathCollider.enabled = false;
        rb2d = GetComponentInParent<Rigidbody2D>();
        anim = GetComponentInParent<Animator>();
        mainCollider = GetComponentInParent<CapsuleCollider2D>();

        SetAnimations();


        zameenNaalTakrao = false;
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

        if (zameenNaalTakrao == true)
        {
            if (runCouroutineOnce == false)
            {
                StartCoroutine(ShootFireBall());
            }
            MoveToPlayer();
        }

        CheckMovementAnimation();
        CheckDeath();

    }

    private void FixedUpdate()
    {
        horizontalMoveSpeed = rb2d.velocity.x;
        SpeedCheck();

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            zameenNaalTakrao = true;
        }

        if (collision.gameObject.tag.Equals("PlayerFire"))
        {
            SetDead();
            CodeMonkey.Utils.UtilsClass.ShakeCamera(0.2f, 0.1f);
        }

        if (collision.gameObject.tag.Equals("Player"))
        {
            if (!dead)
            {
                HealthManager.curHealth -= enemyDamage;
                gameObject.SetActive(false);
                CodeMonkey.Utils.UtilsClass.ShakeCamera(0.2f, 0.1f);
            }
        }

        if (collision.gameObject.tag.Equals("Enemy"))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("PlayerFire"))
        {
            ReduceHealth();
        }
    }

    private void MoveToPlayer()
    {
        if (!dead)
        {
            moving = true;
            anim.SetBool("Moving", true);
            rb2d.AddForce(new Vector2(enemyMoveSpeed * -10 * Time.deltaTime, 0));
        }
    }



    private void CheckMovementAnimation()
    {
        if (horizontalMoveSpeed > 0 || horizontalMoveSpeed < 0)
        {
            Moving();
        }
        if (rb2d.velocity.magnitude == 0)
        {
            StopMoving();
        }
    }

    private void SpeedCheck()
    {
        if (horizontalMoveSpeed > horizontalSpeedCheckHigh)
        {
            rb2d.velocity = new Vector3(horizontalSpeedCheckHigh, transform.position.y, transform.position.z);
        }
        if (horizontalMoveSpeed < horizontalSpeedCheckLow)
        {
            rb2d.velocity = new Vector3(horizontalSpeedCheckLow, transform.position.y, transform.position.z);
        }
    }

    public IEnumerator TurnEnemyOff()
    {
        yield return new WaitForSeconds(0f);
        gameObject.SetActive(false);

        yield return 0;
    }

    public IEnumerator ShootFireBall()
    {
        if (shoot == false)
        {
            anim.SetBool("Shoot", true);
            yield return new WaitForSeconds(1.0f);
            shoot = false;
            anim.SetBool("Shoot", false);
            runCouroutineOnce = true;
            yield return 0;

        }
    }



}
