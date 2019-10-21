using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{


    public float moveSpeed = 2.0f;

    public float upperLimit = 0.0f, lowerLimit = -3.0f;

    private bool dirUp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject();
        ClampMovement();
        
    }

    private void MoveObject()
    {
        //    transform.position = Vector3.Lerp(initialLocation, targetLocation, Mathf.PingPong(Time.time,1));
        if (dirUp)
        {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(-Vector2.up * moveSpeed * Time.deltaTime);
        }
    }

    private void ClampMovement()
    {
        if (transform.position.y >= upperLimit)
        {
            dirUp = false;
        }
        if (transform.position.y <= lowerLimit)
        {
            dirUp = true;
        }
    }
}
