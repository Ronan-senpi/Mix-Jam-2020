using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeFood : MonoBehaviour
{
    [SerializeField]
    LayerMask hitMask;

    private AudioSource audio;
    private void Start()
    {
        audio = this.GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((hitMask.value & (1 << collision.gameObject.layer)) > 0)
        {
            Food food;
            if (collision.transform.TryGetComponent(out food))
            {
                audio.Play();
                FoodManager.Instance.AddFood(food);
                Destroy(collision.transform.gameObject);
            }
        }
    }
}
