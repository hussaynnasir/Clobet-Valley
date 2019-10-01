using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static float pillCounter;

    public float maxPills;

    public Image pillBar;

    // Start is called before the first frame update
    void Start()
    {
        int scenePills = GameObject.FindGameObjectsWithTag("Pill").Length;
        maxPills = scenePills;
    }

    // Update is called once per frame
    void Update()
    {

        pillBar.fillAmount = pillCounter / maxPills;
        PillChecker();   
    }

    private void PillChecker()
    {
        if (pillCounter<=0)
        {
            pillCounter = 0;
        }

        if (pillCounter>=maxPills)
        {
            pillCounter = maxPills;
        }


     


    }
}
