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

    //Check which direction player is looking in
    public static bool LookRight;

    //Check Ground Position
    [SerializeField]
    private bool grounded;
    public LayerMask groundLayers;

    //Check if player is shooting
    private bool shoot;

    //Shooting Mechanism
    public GameObject projectile;
    public Transform shootPosition;

    //The speed at the which the player will move
    public float moveSpeed = 5f;

    //The speed at the which the player will jump
    public float jumpSpeed = 7f;
    


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprt = GetComponent<SpriteRenderer>();
        shoot = false;
        //   grounded = false;
        //moveSpeed = moveSpeed * Time.deltaTime;



        GetPositions();
    }

    // Update is called once per frame
    void Update()
    {

        SetAnimBool();
        GroundCheck();

        InitialLocationSet();


    }

    private void FixedUpdate()
    {
        MovePlayer();
        DirectionCheck();

    }

    private void SetAnimBool()
    {
        anim.SetBool("Moving", moving);
        anim.SetBool("Shoot", shoot);
        anim.SetBool("Grounded", grounded);
    }


    

    private void MovePlayer()
    {
        {   //Move The Player
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
                moving = true;
                sprt.flipX = false;
            }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
                moving = true;
                sprt.flipX = true;
            }
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                if (grounded == true)
                {
                    JumpFunction();
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
            || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.W))
        {
            moving = false;
            rb2d.velocity = new Vector2(0, 0);
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
        if (sprt.flipX==false)
        {
            LookRight = true;
        }
        if (sprt.flipX==true)
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

    public void MoveFunction()
    {
        rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
        moving = true;
    }

    public void JumpFunction()
    {
        if (rb2d.velocity.y == 0)
        {
            rb2d.AddForce(Vector2.up * jumpSpeed);
        }
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

    private void CreateFireBall()
    {
        GameObject fireBall = Instantiate(projectile, shootPosition.position, Quaternion.identity) as GameObject;
        fireBall.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 10f);
        StopAttack();
    }
    

    public void StopMove()
    {
        rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        moving = false;
    }
    
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
      
    }

  


}
