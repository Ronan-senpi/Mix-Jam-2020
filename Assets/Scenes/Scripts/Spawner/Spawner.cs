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
        if(timer <=0 && spawnPoint.Length >0 && gameObjectInstantiate.Length >0)
        {
            int randEnemy = Random.Range(0, gameObjectInstantiate.Length);
            int randSpawnPoint = Random.Range(0, spawnPoint.Length);

            Instantiate(gameObjectInstantiate[randEnemy], spawnPoint[randSpawnPoint].position, transform.rotation);
            difficultTimer = difficultTimer - 0.05f;
            timer = difficultTimer;
            if(difficultTimer <=0.5f)
            {
                difficultTimer = 0.5f;
                timer = difficultTimer;
            }
        }
        
    }
}
