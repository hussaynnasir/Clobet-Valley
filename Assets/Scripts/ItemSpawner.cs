using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] gameObjects;

    public Transform[] spawnPositions;

    public int goLow, goHigh, spLow, spHigh;

    public float spawnInterval = 5.0f;
    public bool spawned;



    // Start is called before the first frame update
    void Start()
    {
        spawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawned == false)
        {
            StartCoroutine(SpawnOnce());
        }

        if (GameManager.checkpointReached == true)
        {
            gameObject.SetActive(false);
        }

        if (GameManager.stageFinished == true)
        {
            gameObject.SetActive(false);
        }
    }

    private void StopSpawn()
    {
        spawned = true;
    }

    private void CreateGameObject()
    {
        GameObject gameObject = Instantiate(gameObjects[Random.Range(goLow, goHigh)], spawnPositions[Random.Range(spLow, spHigh)].position, Quaternion.identity);
        StopSpawn();
    }

    private IEnumerator SpawnOnce()
    {
        CreateGameObject();
        yield return new WaitForSeconds(spawnInterval);
        spawned = false;

        yield return 0;
    }
}
