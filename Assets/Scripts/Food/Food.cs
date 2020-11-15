using Assets.Scripts;
using Assets.Scripts.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : Hitable
{
    [SerializeField]
    FoodType foodType;
    [SerializeField]
    protected FoodState[] foodState;

    public FoodType FoodType { get { return foodType; } }

    public FoodState CurrentState { get; private set; }
    protected int nbHit = 0;
    protected SpriteRenderer sp;
    private void Start()
    {
        if(!TryGetComponent(out sp))
            throw new Exception("SpriteRenderer is MISSING");

        CurrentState = foodState[nbHit];
        sp.sprite = CurrentState.FoodStatesSprite;
        
    }
    protected override void Kill()
    {
        nbHit++;
        if (nbHit < foodState.Length)
        {
            CurrentState = foodState[nbHit];
            sp.sprite = CurrentState.FoodStatesSprite;
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
