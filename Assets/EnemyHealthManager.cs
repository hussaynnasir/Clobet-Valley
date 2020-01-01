using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthManager : MonoBehaviour
{
    public Boss boss;
    public float maxHealth;

    public float curHealth;

    public Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = boss.enemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        curHealth = boss.enemyHealth;

        healthBar.fillAmount = curHealth / maxHealth;
    }
}
