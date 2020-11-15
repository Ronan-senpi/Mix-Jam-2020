using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipDeplacement : MonoBehaviour
{

    public float maxSpeed = 5f;
    public float rotSpeed = 180f;


    public float shipBoundaryRadius = -3.5f;
    public float reverseShipBoundaryRadius = -2f;

    public float borderLeftRight = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // rotation quaternion
        Quaternion rot = transform.rotation;
        float eulerAngle = rot.eulerAngles.z;
        // Change la rotation 
        eulerAngle += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        // Recreate the quaternion
        rot = Quaternion.Euler(0, 0, eulerAngle);
        transform.rotation = rot;

        // Move the Ship
        Vector3 position = transform.position;
        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);
        if(Input.GetAxis("Vertical")<0)
        {
            return;
        }
        else
        {
            position += rot * velocity;
        }


        // Restrict Player Camera
        if (position.y + shipBoundaryRadius > Camera.main.orthographicSize)
        {
            position.y = Camera.main.orthographicSize - shipBoundaryRadius;
        }

        if (position.y - reverseShipBoundaryRadius < -Camera.main.orthographicSize)
        {
            position.y = -Camera.main.orthographicSize + reverseShipBoundaryRadius;
        }

        // SCREEN RATIO
        float screenRatio = Screen.width / Screen.height;
        float widthOrthographicsSize = Camera.main.orthographicSize * screenRatio;

        // BORDER GAUCHE ET DROITE
        if (position.x + borderLeftRight > widthOrthographicsSize)
        {
            position.x = widthOrthographicsSize - borderLeftRight;
        }

        if (position.x - borderLeftRight < -widthOrthographicsSize)
        {
            position.x = -widthOrthographicsSize + borderLeftRight;
        }

        transform.position = position;

    }
}
