using Assets.Scripts.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FillRecette : MonoBehaviour, IDropHandler
{
    [SerializeField]
    Image MainImage;
    [SerializeField]
    FoodInfos[] Ingrediant;
    [SerializeField]
    Texture empty;
    [SerializeField]
    RecetteTimer recetteTimer;
    public bool IsFree { get; private set; }
    int nbIngrediant = 0;
    int nbIngrediantFill = 0;
    // Start is called before the first frame update
    void Start()
    {
        IsFree = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetFree()
    {
        this.IsFree = true;
    }
    internal void Fill(Recettte recettte)
    {
        try
        {
            IsFree = false;
            nbIngrediant = recettte.Ingredients.Length;
            recetteTimer.ResetTimer();
            MainImage.sprite = recettte.Sprite;

            for (int i = 0; i < Ingrediant.Length; i++)
            {
                if (i < recettte.Ingredients.Length)
                {
                    Ingrediant[i].RawImage.texture = recettte.Ingredients[i].Sprite.texture;
                    Ingrediant[i].FoodState = recettte.Ingredients[i].FoodState;
                    Ingrediant[i].FoodType = recettte.Ingredients[i].FoodType;

                }
                else
                {
                    Ingrediant[i].RawImage.texture = empty;
                }
            }
        }
        catch { }
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("RECETTE ON DROP");
        if (eventData.pointerDrag != null)
        {
            var tmp = eventData.pointerDrag.name;
            DragDrop dd;
            if (eventData.pointerDrag.TryGetComponent(out dd))
            {
                var i = Ingrediant.FirstOrDefault(x => x.FoodState == dd.foodStates
                                       && x.FoodType == dd.foodType);
                if (i != null)
                {
                    i.RawImage.texture = empty;
                    nbIngrediantFill++;
                    FoodManager.Instance.Remove(dd.foodStates, dd.foodType);
                    if (nbIngrediantFill >= nbIngrediant)
                    {
                        nbIngrediantFill = 0;
                        this.IsFree = true;
                        FoodManager.Instance.CreateRecette(this);
                    }
                }
            }
        }
    }
}
