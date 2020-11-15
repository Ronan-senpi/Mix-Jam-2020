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

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(targetFood == null && state<3)
        {
            if (Vector2.Distance(transform.position, targetPlayer.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, speed * Time.deltaTime);
                Vector3 direction = targetPlayer.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                rb.rotation = angle;

                GameObject food = GameObject.FindGameObjectWithTag("Food");
                if(food !=null)
                {
                    targetFood =food.GetComponent<Transform>();

                }
            }
        }
        else if (targetFood)
        {
            if(Vector2.Distance(transform.position,targetFood.position)< 10)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetFood.position, speed * Time.deltaTime);
                Vector3 direction = targetFood.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, speed * Time.deltaTime);
                Vector3 direction = targetPlayer.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            }
        }
        else if(state >=3)
        {
            if (Vector2.Distance(transform.position, targetPlayer.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, speed * Time.deltaTime);
                Vector3 direction = targetPlayer.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            }
        }

        if(state == 1)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (state == 2)
        {
            transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);

        }
        else if (state == 3)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

        }



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.layer == LayerMask.NameToLayer("Projectils"))
        {
            state = state - 1;
            if (state <= 0)
            {
                Destroy(this.gameObject);
            }

        }
    }
}
