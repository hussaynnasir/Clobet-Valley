using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private bool collected;
    private Animator anim;
    private SpriteRenderer sprt;
    private PolygonCollider2D polygonCollider;

    public Sprite[] coinSprites;
    public int randomNo;

    // Start is called before the first frame update
    void Awake()
    {
        randomNo = Random.Range(0, 2);

        collected = false;
        sprt = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        polygonCollider = GetComponent<PolygonCollider2D>();

        sprt.sprite = coinSprites[randomNo];
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            polygonCollider.enabled = false;
            anim.SetBool("Collected", true);
            collected = true;
        }
    }

    public void TurnOff()
    {
        gameObject.SetActive(false);
    }
}
