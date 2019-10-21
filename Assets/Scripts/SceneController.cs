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

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }

    

   
}
