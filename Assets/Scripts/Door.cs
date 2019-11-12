using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private SpriteRenderer sprt;

    public Sprite[] doorSprites;

    public AudioManager audioManager;


    // Start is called before the first frame update
    void Start()
    {
        sprt = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            audioManager.PlayThroughDoorSound();
            StartCoroutine(DoorShift());
        }
    }

    private IEnumerator DoorShift()
    {
        sprt.sprite = doorSprites[1];

        yield return new WaitForSeconds(1);

        sprt.sprite = doorSprites[0];

        yield return new WaitForSeconds(1);

        GameManager.stageFinished = true;
        Level2Manager.setPlayerOff = true;

        yield return 0;
    }
}
