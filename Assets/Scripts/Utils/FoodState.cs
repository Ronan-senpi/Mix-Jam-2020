using System;
using UnityEngine;

namespace Assets.Scripts.Utils
{
    [Serializable]
    public class FoodState
    {
        [SerializeField]
        protected FoodStateEnum foodStates;
        [SerializeField]
        protected Sprite foodStatesSprite;

        public Sprite FoodStatesSprite
        {
            get
            {
                return foodStatesSprite;
            }
        }
    }
}
