using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabBalls : MonoBehaviour
{
    public float deathTime = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TurnOff());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator TurnOff()
    {
        yield return new WaitForSeconds(deathTime);
        gameObject.SetActive(false);
        yield return 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            HealthManager.curHealth -= 10;
            gameObject.SetActive(false);
        }
    }
}
