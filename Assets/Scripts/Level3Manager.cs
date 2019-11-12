using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Manager : MonoBehaviour
{
    public GameObject green_Floza;

    public CameraController mainCamera;

    public static bool setPlayerOff;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

    private void TurnOffObstacles()
    {
        if (GameManager.checkpointReached == true)
        {
            mainCamera.enabled = false;

            GameObject.FindGameObjectWithTag("Enemy").SetActive(false);
            
        }
    }
}
