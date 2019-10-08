using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleShooter : MonoBehaviour
{
    public GameObject bubble;
    public Transform bubbleShootingPosition;

    public float bubbleTravelSpeed = 5.0f;

    public float shooterMoveSpeed = 2.0f;

    public bool stopShootingBubbles;

    public static int bubbleHitCounter = 0;

    public float BubbleSpawnTime = 15.0f;

    private bool dirUp;

    public float upperLimit = 0.0f, lowerLimit = -3.0f;

    // Start is called before the first frame update
    void Start()
    {
        stopShootingBubbles = false;
    }

    // Update is called once per frame
    void Update()
    {
        ShooterPositionCheck();
        MoveShooter();
        if (GameManager.checkpointReached == true)
        {
            gameObject.SetActive(false);
        }

        if (stopShootingBubbles == false)
        {
            StartCoroutine(ShootOnce());
        }

    }

    public void CreateBubble()
    {
        GameObject projectile = Instantiate(bubble, bubbleShootingPosition.position, Quaternion.identity);
        bubble.GetComponent<Rigidbody2D>().AddForce(Vector2.right * -bubbleTravelSpeed);
        StopShoot();
    }

    private void ShooterPositionCheck()
    {
        if (transform.position.y >= upperLimit)
        {
            dirUp = false;
        }
        if (transform.position.y <= lowerLimit)
        {
            dirUp = true;
        }
        if (transform.position.z<0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }

    private void MoveShooter()
    {
        //    transform.position = Vector3.Lerp(initialLocation, targetLocation, Mathf.PingPong(Time.time,1));
        if (dirUp)
        {
            transform.Translate(Vector2.up * shooterMoveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(-Vector2.up * shooterMoveSpeed * Time.deltaTime);
        }
    }
    

    public void StopShoot()
    {
        stopShootingBubbles = true;
    }

    private IEnumerator ShootOnce()
    {
        CreateBubble();
        yield return new WaitForSeconds(BubbleSpawnTime);
        stopShootingBubbles = false;

        yield return 0;
    }

}
