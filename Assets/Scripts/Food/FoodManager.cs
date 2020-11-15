using Assets.Scripts.Utils;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    [SerializeField]
    Transform foodStorage;

    List<Food> storagedFood;
    public static FoodManager Instance { get; private set; }

    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            storagedFood = new List<Food>();
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
            this.storagedFood.Add(food);
        }
    }

    public int GetNbFood(FoodStateEnum state, FoodType fType)
    {
        return storagedFood.Count(x => x.CurrentState.State == state
                                       && x.FoodType == fType);
    }


}
