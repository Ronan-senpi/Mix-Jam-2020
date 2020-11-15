using System;
using UnityEngine;

namespace Assets.Scripts.Utils
{
    [Serializable]
    public class Ingredient
    {
        [SerializeField]
        FoodType foodType;
        [SerializeField]
        FoodStateEnum foodState;
        [SerializeField]
        Sprite sprite;

        public FoodType FoodType { get { return foodType; } }
        public FoodStateEnum FoodState { get { return foodState; } }
        public Sprite Sprite { get { return sprite; } }
    }
}
