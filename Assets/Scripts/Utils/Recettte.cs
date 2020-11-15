using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Utils
{
    [Serializable]
    public class Recettte
    {
        [SerializeField]
        Ingredient[] ingredients;
        [SerializeField]
        Sprite sprite;

        public Ingredient[] Ingredients { get { return ingredients; } }
        public Sprite Sprite { get { return sprite; } }
    }

}
