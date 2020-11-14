using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    List<GameObject> storageFood;
    public static FoodManager Instance { get; private set; }

    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            storageFood = new List<GameObject>();
        }
        else
        {
            Destroy(this);
        }
    }
    
    public void AddFood(Food food)
    {
        if (food != null)
        {
            this.storageFood.Add(food.gameObject);
        }
    }
}
