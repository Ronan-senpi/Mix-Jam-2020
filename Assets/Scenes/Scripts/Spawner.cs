using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public Transform[] spawnPoint;
    public GameObject[] gameObjectInstantiate;

    public float timer = 2;
    public float difficultTimer = 2;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            int randEnemy = Random.Range(0, gameObjectInstantiate.Length);
            int randSpawnPoint = Random.Range(0, spawnPoint.Length);

            Instantiate(gameObjectInstantiate[0], spawnPoint[randSpawnPoint].position, transform.rotation);
            timer = difficultTimer;
        }
        
    }
}
