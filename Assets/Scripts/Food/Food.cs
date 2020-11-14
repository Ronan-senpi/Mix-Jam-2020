using Assets.Scripts;
using Assets.Scripts.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : Hitable
{
    [SerializeField]
    protected FoodState[] foodState;

    protected FoodState currentState;
    protected int nbHit = 0;
    protected SpriteRenderer sp;
    private void Start()
    {
        if(!TryGetComponent(out sp))
            throw new Exception("SpriteRenderer is MISSING");

        currentState = foodState[nbHit];
        sp.sprite = currentState.FoodStatesSprite;
        
    }
    protected override void Kill()
    {
        nbHit++;
        if (nbHit < foodState.Length)
        {
            currentState = foodState[nbHit];
            sp.sprite = currentState.FoodStatesSprite;
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
