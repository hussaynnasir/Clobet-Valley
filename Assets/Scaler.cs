using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{   
    
    //variables to check whether enemy is to be enlarged/shrunk or not
    public bool enlargeEnemy, shrinkEnemy;

    private float originalWidth, originalHeight, originalDepth;

    public float targetWidth, targetHeight, targetDepth;

    private Vector3 originalSize, targetSize;

    public float scaleSpeed;



    // Start is called before the first frame update
    void Start()
    {
        GetOriginalScale();
    }

    // Update is called once per frame
    void Update()
    {
        if (enlargeEnemy == true)
        {
            //      StartCoroutine(Enlarge());

        }

    }

    private void GetOriginalScale()
    {
        originalWidth = transform.localScale.x;
        originalHeight = transform.localScale.y;
        originalDepth = transform.localScale.z;
        originalSize = transform.localScale;
    }
    
    private void SetTargetScale()
    {
        targetSize =new Vector3(targetWidth, targetHeight, targetDepth);
    }

    private IEnumerator Enlarge()
    {
        ScaleUp();

        yield return new WaitForSeconds(4);

        enlargeEnemy = false;

        ScaleDown();

        yield return 0;

    }

    private void ScaleUp()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, targetSize, scaleSpeed * Time.deltaTime);
    }

    private void ScaleDown()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, originalSize, scaleSpeed * Time.deltaTime);
    }
       
}
