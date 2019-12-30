using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static float pillCounter;

    public static float maxPills;

    public Image pillBar;

    public GameObject deathPanel;

    public GameObject completionPanel;

    public GameObject platformToDisable;
    
    public static bool checkpointReached;

    public static bool stageFinished;

    public Transform moveToLocation;

    public AudioManager audioManager;

    public AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
        pillCounter = 0;
        float scenePills = GameObject.FindGameObjectsWithTag("Pill").Length;
        
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        maxPills = scenePills;
        stageFinished = false;
        checkpointReached = false;

        deathPanel.SetActive(false);
        completionPanel.SetActive(false);

        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

        pillBar.fillAmount = pillCounter / maxPills;
        PillChecker();   

        if (stageFinished==true)
        {
            Debug.Log("Stage Complete");
            completionPanel.SetActive(true);
        }

        if (checkpointReached==true)
        {
            platformToDisable.SetActive(false);
            Debug.Log("CheckPoint Reached");
        }

        if (HealthManager.dead)
        {
            deathPanel.SetActive(true);
            audioManager.PlayDeathSound();
            music.Stop();
        }


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
