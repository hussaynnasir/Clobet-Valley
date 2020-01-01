using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPatrol : MonoBehaviour
{
    public float moveSpeed;

    public float rightLimit = 0.0f, leftLimit = 0.0f;
    private bool dirRight;

    private float length, height, width;
    

    // Start is called before the first frame update
    void Start()
    {
        GetMeasurements();
        dirRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        PositionCheck();
        HorizontalMove();

        if (GameManager.checkpointReached == true)
        {
            gameObject.SetActive(false);
        }
        
    }

    private void PositionCheck()
    {
        if (transform.position.x >= rightLimit)
        {
            dirRight = false;
            transform.localScale = new Vector3(-length, height, width);
        }

        if (transform.position.x <= leftLimit)
        {
            dirRight = true;
            transform.localScale = new Vector3(length, height, width);
        }

        if (transform.position.z < 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }
    
    private void HorizontalMove()
    {
        if (dirRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(-Vector2.right * moveSpeed * Time.deltaTime);
        }
    }

    private void GetMeasurements()
    {
        length = transform.localScale.x;
        height = transform.localScale.y;
        width = transform.localScale.z;
    }
}
