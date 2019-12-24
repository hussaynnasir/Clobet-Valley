using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rollables : MonoBehaviour
{
    public float rollSpeed = 2.0f;

    public float rollableHealth = 2.0f;

    public float damageAmount = 10.0f;

    private float rollableCurrentSpeed = 0;

    public bool rollableMove;

    private Rigidbody2D rb2d;


    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rollableMove = false;

        rb2d.velocity = new Vector2(rollSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (rollableHealth <= 0)
        {
            gameObject.SetActive(false);
        }

        if (GameManager.checkpointReached==true)
        {
            gameObject.SetActive(false);
        }

        if (rollableMove == true)
        {
            rb2d.AddForce(new Vector2(rollSpeed * 10 * Time.deltaTime, 0));
            rollableCurrentSpeed = rb2d.velocity.magnitude;
            SetZRotation();
        }
    }

    private void SetZRotation()
    {
        transform.Rotate(0, 0, 36 * rollableCurrentSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("OutsideFrame")) 
        {
            gameObject.SetActive(false);
        }

        if (collision.gameObject.layer == 8)
        {
            rollableMove = true;
        }

        if (collision.gameObject.tag.Equals("Player"))
        {
            HealthManager.curHealth -= damageAmount;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("OutsideFrame"))
        {
            gameObject.SetActive(false);
        }
    }
}
