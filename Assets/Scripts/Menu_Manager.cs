using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_Manager : MonoBehaviour
{
    public GameObject levelSelectPanel;

    // Start is called before the first frame update
    void Start()
    {
        levelSelectPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectLevel()
    {
        levelSelectPanel.SetActive(true);
    }

    public void Back()
    {
        levelSelectPanel.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }

}
