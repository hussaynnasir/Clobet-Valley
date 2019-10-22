using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator anim;
    private SpriteRenderer sprt;

    //The starting of the player
    private Vector2 positionInitial;

    //Check if the player is moving
    private bool moving;
    private bool runMove;

    public static bool hide;

    //Check which direction player is looking in
    public static bool LookRight;

    //Check Ground Position
    [SerializeField]
    public bool grounded;
    public LayerMask groundLayers;

    //Check if player is shooting
    private bool shoot;

    public bool dead;

    //Shooting Mechanism
    public GameObject projectile;
    public Transform shootPosition;

    //Sound
    public AudioManager audioManager;

    //The speed at the which the player will move
    public float moveSpeed = 5f;

    //The speed at the which the player will jump
    public float jumpSpeed = 7f;

    public CapsuleCollider2D deathCollider, hideCollider;

    private CapsuleCollider2D normalCollider;

    public GameManager gameManager;



    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprt = GetComponent<SpriteRenderer>();
        normalCollider = GetComponent<CapsuleCollider2D>();
        shoot = false;
        //   grounded = false;
        //moveSpeed = moveSpeed * Time.deltaTime;

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        GetPositions();
    }

    // Update is called once per frame
    void Update()
    {

        SetAnimBool();
        GroundCheck();
        DeathCheck();

        InitialLocationSet();

        if (GameManager.stageFinished == false)
        {
            AutoMovetoLocation();
        }

        if (GameManager.stageFinished == true)
        {
            StopMove();
        }

    }

    private void DeathCheck()
    {
        dead = HealthManager.dead;
        if (dead == true)
        {
            normalCollider.enabled = false;
            hideCollider.enabled = false;
            deathCollider.enabled = true;
        }
        else
        {
            deathCollider.enabled = false;
            normalCollider.enabled = true;
        }

    }

    private void FixedUpdate()
    {
        if (!dead || !GameManager.stageFinished || !GameManager.checkpointReached)
        {
            MovePlayer();
        }
        if (dead || GameManager.stageFinished)
        {
            StopMove();
        }
        DirectionCheck();

    }

    private void SetAnimBool()
    {
        anim.SetBool("Moving", moving);
        anim.SetBool("Shoot", shoot);
        anim.SetBool("Grounded", grounded);
        anim.SetBool("Dead", dead);
        anim.SetBool("Run", runMove);
        anim.SetBool("Hide", hide);
    }




    private void MovePlayer()
    {
        {   //Move The Player
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                //    rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
                //    moving = true;
                //    sprt.flipX = false;
                MoveFunction(moveSpeed);
            }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                //    rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
                //    moving = true;
                //    sprt.flipX = true;
                MoveFunction(-moveSpeed);
            }
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                if (grounded == true)
                {
                    JumpFunction(jumpSpeed);
                    grounded = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                StopAttack();
            }

            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                Hide();
            }

            {
                /*
                     if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
                    {
                      transform.Translate(Vector2.down * Input.GetAxis("Vertical") * -moveSpeed * Time.deltaTime);
                      moving = true;
                    }
                 */
            }
        }

        //Check if the player has stopped moving
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)
            || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            //moving = false;
            //rb2d.velocity = new Vector2(0, 0);
            StopMove();
            StopHiding();
        }

    }



    private void GetPositions()
    {
        positionInitial = gameObject.transform.position;
    }

    private void InitialLocationSet()
    {
        if (transform.position.x < positionInitial.x)
        {
            transform.position = new Vector2(positionInitial.x, transform.position.y);
        }
    }

    private void DirectionCheck()
    {
        if (sprt.flipX == false)
        {
            LookRight = true;
        }
        if (sprt.flipX == true)
        {
            LookRight = false;
        }
    }

    private void GroundCheck()
    {
        grounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 2.5f, transform.position.y - 2.2f),
            new Vector2(transform.position.x + 2.5f, transform.position.y - 2.25f), groundLayers);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawCube(new Vector2(transform.position.x, transform.position.y - 3.2505f),
            new Vector2(1, -2.2501f));
    }

    public void MoveFunction(float moveSpeed)
    {
        rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
        if (GameManager.checkpointReached == false)
        {
            runMove = true;
            moving = false;
        }

        if (GameManager.checkpointReached == true)
        {
            runMove = false;
            moving = true;
        }

        if (moveSpeed < 0)
        {
            sprt.flipX = true;
        }
        if (moveSpeed > 0)
        {
            sprt.flipX = false;
        }
    }

    public void StopMove()
    {
        rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        moving = false;
        runMove = false;
    }

    public void JumpFunction(float jumpSpeed)
    {
        if (rb2d.velocity.y == 0)
        {
            rb2d.AddForce(Vector2.up * jumpSpeed);
        }
    }

    public void StopJump()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
    }

    public void Attack()
    {
        if (shoot == true)
        {
            shoot = false;
        }
        shoot = true;
    }

    public void StopAttack()
    {
        shoot = false;
    }

    public void Hide()
    {
        hide = true;
        hideCollider.enabled = true;
        normalCollider.enabled = false;
    }

    public void StopHiding()
    {
        hide = false;
        hideCollider.enabled = false;
        normalCollider.enabled = true;
    }

    private void CreateFireBall()
    {
        GameObject fireBall = Instantiate(projectile, shootPosition.position, Quaternion.identity) as GameObject;
        fireBall.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 10f);
        StopAttack();
    }
    

  
    
    public IEnumerator Knockback(float knockDur, float knockPower, Vector3 knockDirection)
    {
        float timer = 0;

        while (knockDur>timer)
        {
            timer += Time.deltaTime;
            rb2d.AddForce(new Vector3(knockDirection.x * -100, knockDirection.y * knockPower, transform.position.z));
        }

        yield return 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Pill"))
        {
            GameManager.pillCounter += 1;
            audioManager.PlayCollectSound();
            if (collision.name.Equals("Pill"))
            {
                HealthManager.curHealth += 20;
                collision.gameObject.SetActive(false);
            }
            else
            {
                HealthManager.curHealth += 4;
            }
        }
        
        if (collision.tag.Equals("Checkpoint"))
        {
            GameManager.checkpointReached = true;
        }
        
    }

    public void AutoMovetoLocation()
    {
        if (GameManager.checkpointReached==true)
        { 
            MoveFunction(moveSpeed);
            if (transform.position.x == gameManager.moveToLocation.position.x)
            {
                GameManager.stageFinished = true;
            }
        }
    }

    




}
