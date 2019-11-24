using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    private static int totalCollectibles;

    public string itemName;

    public TextMeshProUGUI scoreCounter;

  //  public string scoreMessage;

    // Start is called before the first frame update
    void Start()
    {
        totalCollectibles = GameObject.FindGameObjectsWithTag("Pill").Length;
        Debug.Log(totalCollectibles);
    }

    // Update is called once per frame
    void Update()
    {
        scoreCounter.text = "Total " + itemName + " Collected = " + GameManager.pillCounter + "/" + totalCollectibles;
    }
}
