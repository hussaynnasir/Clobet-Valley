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
    public float tuberTimer;

    private bool _stopShootProjectile;

    // Start is called before the first frame update
    void Start()
    {
        _stopShootProjectile = false;
    }

    // Update is called once per frame
    void Update()
    {
        throwPointPosition = new Vector2(throwPoint.transform.position.x, throwPoint.transform.position.y);

        if (GameManager.checkpointReached==true)
        {
            gameObject.SetActive(false);
        }

        if (_stopShootProjectile==false)
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
        _stopShootProjectile = true;
    }
    
    private IEnumerator ShootOnce()
    {
        CreateProjectile();
        yield return new WaitForSeconds(tuberTimer);
        _stopShootProjectile = false;

        yield return 0;
    }



}
