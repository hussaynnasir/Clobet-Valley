using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    private float _originalWidth, _originalHeight, _originalDepth;
    public Vector3 _originalSize, _targetSize;

    //The check for whether enemy is big and invulnerable
    public static bool _scaleActive;

    // The measurements for size to be increased to
    public float targetWidth, targetHeight, targetDepth;
    // The speed at which the size increases
    public float scaleSpeed;
    //Time that enemy is invulnerable
    public float invulnerableTime = 4.0f;
    //variables to check whether enemy is to be enlarged/shrunk or not
    public bool enlargeEnemy, shrinkEnemy;

    public float scaleRandLow = 8.0f, scaleRandHigh = 16.0f;

    private Boss boss;
    public float bossInitialHealth;

    private bool allDone;

    // Start is called before the first frame update
    void Start()
    {
        boss = GetComponent<Boss>();
        GetOriginalScale();
        SetTargetScale();

        allDone = false;
        bossInitialHealth = boss.enemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (boss.enemyHealth == bossInitialHealth / 2)
        {
            if (allDone == false)
            {
                _scaleActive = true;
            }
        }

        if (boss.enemyHealth != bossInitialHealth / 2) ;
        {
        //    _scaleActive = false;
        }
    }

    private void FixedUpdate()
    {
        InvulnerableCheck();
    }

    private void GetOriginalScale()
    {
        _originalWidth = transform.localScale.x;
        _originalHeight = transform.localScale.y;
        _originalDepth = transform.localScale.z;
        _originalSize = new Vector3(_originalWidth, _originalHeight, _originalDepth);
    }
    
    private void SetTargetScale()
    {
        _targetSize =new Vector3(targetWidth, targetHeight, targetDepth);
    }

    private void InvulnerableCheck()
    {
   //     StartCoroutine(JustDoIt());
        if (_scaleActive)
        {
            StartCoroutine(Scale());
            gameObject.tag = "BossInvulnerable";
        }
        if (!_scaleActive)
        {
            enlargeEnemy = false;
            gameObject.tag = "Boss";
        }

        if (enlargeEnemy == true)
        {
            StartCoroutine(ScaleUp());
        }

        if (shrinkEnemy==true)
        {
            StartCoroutine(ScaleDown());
        }

    }

        private IEnumerator Scale()
    {
        {
            enlargeEnemy = true;
            yield return new WaitForSeconds(invulnerableTime);
            enlargeEnemy = false;
            _scaleActive = false;
            shrinkEnemy = true;
            
        }
        yield return null;
    }

    private IEnumerator ScaleUp()
    {
        {
            while (transform.localScale != _targetSize) 
            {
                transform.localScale = Vector3.Lerp(transform.localScale, _targetSize, scaleSpeed * Time.deltaTime);
                yield return null;
            } 
        }
        enlargeEnemy = false;

    }

    private IEnumerator ScaleDown()
    {
        _scaleActive = false;
        allDone = true;
        while (transform.localScale != _originalSize) 
        {
            transform.localScale = Vector3.Lerp(_targetSize, _originalSize, scaleSpeed * Time.time);
            yield return null;
        }
        
        if (transform.localScale == _originalSize)
        {
            shrinkEnemy = false;
         
        }
    }



}
