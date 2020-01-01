using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    public float offTimer = 4.0f;
    public float healthIncreaseAmount = 10.0f;
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
        yield return new WaitForSeconds(offTimer);
        gameObject.SetActive(false);

        yield return 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            HealthManager.curHealth += healthIncreaseAmount;
            gameObject.SetActive(false);
        }
    }
}
