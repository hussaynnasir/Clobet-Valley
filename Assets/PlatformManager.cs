using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformManager : MonoBehaviour
{
    public GameObject leftPanel, rightPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlatformCheck();
    }

    private void PlatformCheck()
    {
        if (Application.platform==RuntimePlatform.Android)
        {
            leftPanel.SetActive(true);
            rightPanel.SetActive(true);
        }
        
        

        else
        {
            leftPanel.SetActive(false);
            rightPanel.SetActive(false);
        }
    }
}
