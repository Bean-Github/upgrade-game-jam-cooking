using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoppingStation : CookingStation
{
    public GameObject[] choppedObjects;

    public override void PlayerInsideBehavior()
    {
        base.PlayerInsideBehavior();

        // Check if compatible
        if (playerHolding.heldObject == null)
        {
            return;
        }

        switch (playerHolding.currentIngredient.ingredientData.ingredient)
        {
            case GameTypes.Ingredient.Lettuce:
                break;
            case GameTypes.Ingredient.Tomato:
                break;
            case GameTypes.Ingredient.Onion:
                print("HI");
                break;
            default:
                break;
        }
    }
}
