using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    private SpriteRenderer _sprt;
    private bool _intervalShotCheck;
    private bool _dirRight;
    
    public float leftLimit = 0.0f, rightLimit = 9.0f;
    public bool shootCheck;
    //The time taken before the boss fires next shot
    public float shootIntervalTime = 5.0f;

    // Start is called before the first frame update
    new void Start()
    {
        _sprt = GetComponent<SpriteRenderer>();

        deathCollider.enabled = false;
        rb2d = GetComponentInParent<Rigidbody2D>();
        anim = GetComponentInParent<Animator>();
        mainCollider = GetComponentInParent<CapsuleCollider2D>();

        _dirRight = false;
        _intervalShotCheck = false;
    }

    // Update is called once per frame
    new void Update()
    {
        if (rb2d.velocity.x != 0)
        {
            moving = true;
        }
        if (rb2d.velocity.x == 0)
        {
            moving = false;
        }
    
        if (_intervalShotCheck==false)
        {
            StartCoroutine(FixIntervalShots());
        }
        
        if (shootCheck==false)
        { 
            BossPatrol();
        }

        SetAnimations();
     
        CheckDeath();

        if (enemyHealth <= 0)
        {
            GameManager.checkpointReached = true;
            GameManager.stageFinished = true;
        }

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

    public void MoveFunction(float moveSpeed)
    {
        if (!dead)
        {
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
            if (moveSpeed < 0)
            {
                _sprt.flipX = true;
            }
            if (moveSpeed > 0)
            {
                _sprt.flipX = false;
            }
        }
    }


    private void BossPatrol()
    {
        if (_dirRight)
            {
                MoveFunction(enemyMoveSpeed);
            }

            else if (!_dirRight)
            {
                MoveFunction(-enemyMoveSpeed);
            }

            if (transform.position.x <= leftLimit)
            {
                _dirRight = true;
                MoveFunction(enemyMoveSpeed);
            }


            if (transform.position.x >= rightLimit)
            {
                _dirRight = false;
                MoveFunction(-enemyMoveSpeed);
            }
    }
 
    private IEnumerator BossAttack()
    {
         if (shootCheck == false)
        {
            shootCheck = true;
        }
        if (fireballCreated == true)
        {
            fireballCreated = false;
        }
        _sprt.flipX = true;
        Attack();

        yield return new WaitForSeconds(1.3f);

        StopAttack();

        shootCheck = false;

        fireballCreated = false;
        
        yield return 0;
    }
    

    private IEnumerator FixIntervalShots()
    {
        _intervalShotCheck = true;
        StartCoroutine(BossAttack());
        yield return new WaitForSeconds(shootIntervalTime);
        _intervalShotCheck = false;
        yield return 0;
    }
   
}
