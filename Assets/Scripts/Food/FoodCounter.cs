using Assets.Scripts.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodCounter : MonoBehaviour
{
    [SerializeField]
    FoodStateEnum foodState;
    [SerializeField]
    FoodType foodType;
    Text txt;
    private void Start()
    {
        txt = GetComponent<Text>();
    }
    private void Update()
    {
        txt.text = FoodManager.Instance.GetNbFood(foodState, foodType).ToString();
    }
}
