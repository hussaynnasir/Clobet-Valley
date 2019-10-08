using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float bubbleMoveSpeed = 2.0f;

    private int bubbleHealthCounter = 2;
    

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(-bubbleMoveSpeed, 0);
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
}
