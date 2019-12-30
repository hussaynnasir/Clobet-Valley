using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float offTime = 3.0f;
    public float offAfterHitTime = 0f;
    public float damageAmount = 10.0f;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(TurnOff());
        anim.SetBool("Explode", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator TurnOff()
    {
        yield return new WaitForSeconds(offTime);
        gameObject.SetActive(false);
        yield return 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            StartCoroutine(Explode());
        }
    }

    private IEnumerator Explode()
    {
        anim.SetBool("Explode", true);
        HealthManager.curHealth -= damageAmount;
        yield return new WaitForSeconds(offAfterHitTime);
        gameObject.SetActive(false);
        yield return 0;
    }
}
