using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform myTarget;
    // Update is called once per frame
    void Update()
    {
       if(myTarget!=null)
        {
            Vector3 targetPosition = myTarget.position;
            targetPosition.z = transform.position.z;
            
            transform.position = targetPosition;
        }
    }
}
