using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController: MonoBehaviour
{
    public static Scene scene;
    public static string sceneName;
    private int sceneNo;

    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
       
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Restart()
    {
        sceneNo = scene.buildIndex;
        SceneManager.LoadScene(sceneNo);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void LoadLevel4()
    {
        SceneManager.LoadScene("Level 4");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void PauseMenu()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
    

   
}
