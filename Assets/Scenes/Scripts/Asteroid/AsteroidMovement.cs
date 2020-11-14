using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{

    public float maxThrust;
    public float maxTorque;
    public Rigidbody2D rb;

    // Border Screen 

    public float screenTop;
    public float screenBottom;
    public float screenLeft;
    public float screenRight;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        Vector2 thrust = new Vector2(Random.Range(-maxThrust, maxThrust), Random.Range(-maxThrust, maxThrust));
        float torque = Random.Range(-maxTorque, maxTorque);

        rb.AddForce(thrust);
        rb.AddTorque(torque);
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosition = transform.position;
        if(transform.position.y >screenTop)
        {
            newPosition.y = screenBottom;
        }

        if(transform.position.y < screenBottom)
        {
            newPosition.y = screenTop;
        }

        if(transform.position.x >screenRight)
        {
            newPosition.x = screenLeft;
        }

        if(transform.position.x < screenLeft)
        {
            newPosition.x = screenRight;
        }

        transform.position = newPosition;
    }
}
