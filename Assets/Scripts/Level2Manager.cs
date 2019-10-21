using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2Manager : MonoBehaviour
{
    public GameObject coins;

    public GameObject brown_Floza, green_Floza;

    public GameObject dressMessagePanel;


    public static bool dressCollected;

    public static bool switchNow;

    public CameraController mainCamera;

    public static bool setPlayerOff;
    


    // Start is called before the first frame update
    void Start()
    {
        setPlayerOff = false;
        dressCollected = false;
        switchNow = false;
        coins.SetActive(true);
        dressMessagePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ActivateMessagePanel();
        SwitchCharacters();
        TurnOffObstacles();
        SetPlayerOff();

        
    }

   private void SetPlayerOff()
    {
        if (GameManager.stageFinished)
        {
            green_Floza.SetActive(false);
        }
    }

    private void ActivateMessagePanel()
    {
        if (dressCollected == true)
        {
            dressMessagePanel.SetActive(true);
            dressCollected = false;
            Time.timeScale = 0;
            
        }
    }

    public void PressOk()
    {
        dressMessagePanel.SetActive(false);
        switchNow = true;
        Time.timeScale = 1;
    }

    private void SwitchCharacters()
    {
        if (switchNow == true)
        {

            mainCamera.player = green_Floza.GetComponent<PlayerController>();
            brown_Floza.SetActive(false);
            green_Floza.SetActive(true);
           
        }
    }

    private void TurnOffObstacles()
    {
        if (GameManager.checkpointReached == true)
        {
            mainCamera.enabled = false;

            GameObject.FindGameObjectWithTag("Enemy").SetActive(false);

            GameObject.FindGameObjectWithTag("Bubble").SetActive(false);
        }
    }
}
