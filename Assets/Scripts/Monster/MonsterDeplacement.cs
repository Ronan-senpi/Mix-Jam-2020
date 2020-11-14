using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDeplacement : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;

    private Transform targetFood;
    private Transform targetPlayer; 

    // Start is called before the first frame update
    void Start()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position,targetPlayer.position)>stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, speed * Time.deltaTime);
        }
        
    }
}
