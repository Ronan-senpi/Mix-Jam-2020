using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFood : MonoBehaviour
{
    public MonsterDeplacement monsterState;
    public int monsterIntState;
    // Start is called before the first frame update
    void Start()
    {
        monsterState =this.gameObject.GetComponent<MonsterDeplacement>();
        monsterIntState = monsterState.state;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="Food")
        {
            monsterIntState = monsterIntState + 1;
            monsterState.state = monsterIntState;
            Destroy(collision.gameObject);
        }
    }
}
