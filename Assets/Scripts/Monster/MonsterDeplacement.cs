using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDeplacement : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;

    private Transform targetFood;
    private Transform targetPlayer;

    public bool food;

    public int state = 1; 

    // Start is called before the first frame update
    void Start()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(targetFood == null && state<3)
        {
            if (Vector2.Distance(transform.position, targetPlayer.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, speed * Time.deltaTime);
                GameObject food = GameObject.FindGameObjectWithTag("Food");
                if(food !=null)
                {
                    targetFood =food.GetComponent<Transform>();

                }
            }
        }
        else if (targetFood)
        {
            if(Vector2.Distance(transform.position,targetFood.position)< 5)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetFood.position, speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, speed * Time.deltaTime);
            }
        }
        else if(state >=3)
        {
            if (Vector2.Distance(transform.position, targetPlayer.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, speed * Time.deltaTime);
            }
        }

        
        
        
    }
}
