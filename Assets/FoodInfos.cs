using Assets.Scripts.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodInfos : MonoBehaviour
{
    private void Start()
    {
        RawImage = GetComponent<RawImage>();
    }
    public RawImage RawImage { get; set; }
    public FoodType FoodType { get; set; } 
    public FoodStateEnum FoodState { get; set; }
}
