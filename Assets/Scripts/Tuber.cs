using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuber : MonoBehaviour
{

    public GameObject projectile;
    public GameObject tubePosition;

    public GameObject throwPoint;
    public Vector2 throwPointPosition;

    public float projectileSpeed;

    public bool stopShootProjectile;

    public float tuberTimer;

   



    // Start is called before the first frame update
    void Start()
    {
        stopShootProjectile = false;
    }

    // Update is called once per frame
    void Update()
    {
        throwPointPosition = new Vector2(throwPoint.transform.position.x, throwPoint.transform.position.y);

        if (GameManager.checkpointReached==true)
        {
            gameObject.SetActive(false);
        }

        if (stopShootProjectile==false)
        {
            StartCoroutine(ShootOnce());
        }

    }

    public void CreateProjectile()
    {
        GameObject proj = Instantiate(projectile, tubePosition.transform.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().AddForce(throwPointPosition * projectileSpeed);
        StopShoot();
    }        
            
    public void StopShoot()
    {
        stopShootProjectile = true;
    }
    
    private IEnumerator ShootOnce()
    {
        CreateProjectile();
        yield return new WaitForSeconds(tuberTimer);
        stopShootProjectile = false;

        yield return 0;
    }



}
