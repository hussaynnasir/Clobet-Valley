using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private Vector2 initialLocation;

    private Animator anim;
    
    public bool playerColliding;

    public float platformMoveSpeed = 1.0f;

    public PlayerController playerController;

    BoxCollider2D boxCollider2D;
        

    // Start is called before the first frame update
    void Start()
    {
        playerColliding = false;
        initialLocation = transform.position;
        boxCollider2D = GetComponent<BoxCollider2D>();

        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // PositionCheck();
        // PositionReturn();
        SetCollider();
        AnimationCheck();
    }

    private void PositionCheck()
    {
        if (transform.position.y >= initialLocation.y) 
        {
    //        returnToPosition = false;
        }

        if (transform.position.y <= initialLocation.y)
        {
      //      returnToPosition = true;
        }
    }

    private void SetCollider()
    {
        if (playerController.grounded == true) 
        {
            if (playerColliding == false) 
            {
                boxCollider2D.enabled = false;
            }
        }
        if (playerController.grounded == false) 
        { 
            if (playerColliding == true) ;
            {
                boxCollider2D.enabled = true;
            }
        }
    }

    private void AnimationCheck()
    {
        if (playerColliding == true) 
        {
            anim.enabled = false;
        }
        if (playerColliding == false) 
        {
            anim.enabled = true;
        }
    }

    private void PositionReturn()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            playerColliding = true;
         
        //    Debug.Log("Declining");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            playerColliding = false;
        
        //    Debug.Log("Not Declining");
        }
    }
}
