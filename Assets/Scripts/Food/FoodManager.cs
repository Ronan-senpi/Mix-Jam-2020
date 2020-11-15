using Assets.Scripts.Utils;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    List<Food> storagedFood;
    [SerializeField]
    Recettte[] recette;
    [SerializeField]
    FillRecette recetteStorage1;
    [SerializeField]
    FillRecette recetteStorage2;
    [SerializeField]
    FillRecette recetteStorage3;
    [SerializeField]
    FillRecette recetteStorage4;

    public static FoodManager Instance { get; private set; }

    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            storagedFood = new List<Food>();

            recetteStorage1.Fill(recette[Random.Range(0, recette.Length)]);
            recetteStorage2.Fill(recette[Random.Range(0, recette.Length)]);
            recetteStorage3.Fill(recette[Random.Range(0, recette.Length)]);
            recetteStorage4.Fill(recette[Random.Range(0, recette.Length)]);
        }
        else
        {
            Destroy(this);
        }
    }



    public void CreateRecette(FillRecette fillRecette)
    {

        fillRecette.Fill(recette[Random.Range(0, recette.Length)]);


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

    public void Remove(FoodStateEnum state, FoodType fType)
    {
        var f = storagedFood.Where(x => x.CurrentState.State == state && x.FoodType == fType).ToList();
        var tmp = storagedFood.Count(x => x.CurrentState.State == state && x.FoodType == fType);

        storagedFood.RemoveAll(x => x.CurrentState.State == state && x.FoodType == fType);
    }

}
