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

    //The speed at the which the player will move
    public float moveSpeed = 5f;

    //The limit the gameobject can move either up or down
    public float upperBoundary, lowerBoundary;

    //The Enemy to be attacked
    public Transform enemyPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprt = GetComponent<SpriteRenderer>();
        

        GetPositions();
    }

    // Update is called once per frame
    void Update()
    {
        CheckPositionBoundary();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        {   //Move The Player
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector2.right * Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime);
                moving = true;
                sprt.flipX = false;
            }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector2.left * Input.GetAxis("Horizontal") * -moveSpeed * Time.deltaTime);
                moving = true;
                sprt.flipX = true;
            }
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector2.up * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
         //       moving = true;
            }
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector2.down * Input.GetAxis("Vertical") * -moveSpeed * Time.deltaTime);
           //     moving = true;
            }
        }
        //Check if the player has stopped moving
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)
            || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.W))
        {
            moving = false;
        }

        if (moving==true)
        {
            anim.SetBool("Moving", true);
        }
        else
        {
            anim.SetBool("Moving", false);
        }
    }

    private void CheckPositionBoundary()
    {
        if (transform.position.y<lowerBoundary)
        {
            transform.position = new Vector2(transform.position.x, lowerBoundary);
        }
        if (transform.position.y>upperBoundary)
        {
            transform.position = new Vector2(transform.position.x, upperBoundary);
        }
    }

    private void GetPositions()
    {
        positionInitial = gameObject.transform.position;
    }

    public void AttackEnemy()
    {
        Vector3 desiredPos = enemyPosition.position - new Vector3(0.5f,0);
        Vector3 playerPos = gameObject.transform.position;
        Vector3 smoothedPos = Vector3.Lerp(playerPos, desiredPos, moveSpeed * Time.deltaTime);
        transform.position = smoothedPos;
        CodeMonkey.Utils.UtilsClass.ShakeCamera(0.1f, 0.1f);
    }
    
}
