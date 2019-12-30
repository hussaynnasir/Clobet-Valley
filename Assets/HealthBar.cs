using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    Vector3 localScale;
    public Enemy enemy;
    private static float healthPoints;
    public float multiplier = 0.04f;

    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        healthPoints = enemy.enemyHealth * multiplier;
        localScale.x = healthPoints;
        transform.localScale = localScale;
    }
}
