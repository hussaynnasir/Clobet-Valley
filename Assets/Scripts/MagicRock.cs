using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicRock : MonoBehaviour
{

    public int rockHealth = 3;
    public float rockMoveSpeed = 2.0f;
    public bool dirUp;

    private SpriteRenderer sprt;

    public float upperLimit = 0.0f, lowerLimit = -3.0f;


    // Start is called before the first frame update
    void Start()
    {
        sprt = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveStone();
        StonePositionCheck();
        StoneHealthCheck();
    }

    private void StonePositionCheck()
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
    

    private void MoveStone()
    {
        //    transform.position = Vector3.Lerp(initialLocation, targetLocation, Mathf.PingPong(Time.time,1));
        if (dirUp)
        {
            transform.Translate(Vector2.up * rockMoveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(-Vector2.up * rockMoveSpeed * Time.deltaTime);
        }
    }

    private void StoneHealthCheck()
    {
        if (rockHealth <= 0)
        {
            rockHealth = 0;
            gameObject.SetActive(false);
        }
    }

    private void ColourShift()
    {
        sprt.color = Color.Lerp(sprt.color, Color.white, Time.deltaTime / 1.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            HealthManager.curHealth -= 20;

            CodeMonkey.Utils.UtilsClass.ShakeCamera(0.2f, 0.1f);
        }

        if (collision.tag.Equals("PlayerFire"))
        {
            collision.gameObject.SetActive(false);
            rockHealth -= 1;
            CodeMonkey.Utils.UtilsClass.ShakeCamera(0.2f, 0.1f);
        }
    }
}
