﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float bubbleMoveSpeed = 2.0f;

    public float barrelMoveSpeed = 2.0f;

    private int bubbleHealthCounter = 2;

    public float donutMoveSpeedCurrent = 0;

    public float damageAmount = 10.0f;

    public bool donutMove;

    public string objectName;
    

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        objectName = gameObject.name;
        donutMove = false;
        rb2d = GetComponent<Rigidbody2D>();
        
        if (objectName=="Bubble" || objectName=="Bubble(Clone)")
        { 
            rb2d.velocity = new Vector2(-bubbleMoveSpeed, 0);
        }

        if (objectName=="Donut" || objectName=="Donut(Clone)")
        {
            bubbleHealthCounter = 1;
        }

        if (objectName == "Barrel" || objectName == "Barrel(Clone)")
        {
            rb2d.velocity = new Vector2(-barrelMoveSpeed, 0);
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (bubbleHealthCounter <= 0)
        {
            gameObject.SetActive(false);
        }

        if (GameManager.checkpointReached==true)
        {
            gameObject.SetActive(false);
        }

        if (objectName == "Donut" || objectName == "Donut(Clone)")
        {
            if (donutMove == true)
            {
                rb2d.AddForce(new Vector2(-bubbleMoveSpeed * 10 * Time.deltaTime, 0));
                donutMoveSpeedCurrent = rb2d.velocity.magnitude;
                SetZRotation();
            }
        }

        if (objectName == "Barrel" || objectName == "Barrel(Clone)")
        {
            if (donutMove == true)
            {
                rb2d.AddForce(new Vector2(-barrelMoveSpeed * 10 * Time.deltaTime, 0));
            }
        }
    }

    public void SetZRotation()
    {
        transform.Rotate(0, 0, 36 * donutMoveSpeedCurrent * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("OutsideFrame"))
        {
            bubbleHealthCounter -= 1;
        }

        if (collision.tag.Equals("Player"))
        {
            HealthManager.curHealth -= 10;
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("OutsideFrame"))
        {
            bubbleHealthCounter -= 1;
        }

        if (collision.gameObject.layer==8)
        {
            donutMove = true;
        }

        if (collision.gameObject.tag.Equals("Player"))
        {
            HealthManager.curHealth -= damageAmount;
            gameObject.SetActive(false);
        }

        if (collision.gameObject.tag.Equals("Enemy"))
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
        
    }

}
