using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeFood : MonoBehaviour
{
    [SerializeField]
    LayerMask hitMask;

    List<GameObject> storageFood = new List<GameObject>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((hitMask.value & (1 << collision.gameObject.layer)) > 0)
        {
            Food food;
            if (collision.transform.TryGetComponent(out food))
            {
                this.storageFood.Add(collision.transform.gameObject);
                Destroy(collision.transform.gameObject);
            }
        }
    }
}
