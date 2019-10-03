using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{

    public  float maxHealth = 100f;
    public static float curHealth;
    public static bool dead;

    public Image healthBar;

    
    

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (curHealth > 100) 
        {
            curHealth = 100;
        }


        if (curHealth <= 0) 
        {
            curHealth = 0;
            dead = true;
        }

        healthBar.fillAmount = curHealth / maxHealth;
       
        
    }




}
