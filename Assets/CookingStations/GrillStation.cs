using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrillStation : CookingStation
{
    public IngredientScriptableObject cookedMeat;

    public override void PlayerInsertBehavior()
    {
        base.PlayerInsertBehavior();

        // Check if compatible
        if (playerHolding.heldObject == null || playerHolding.CompareTag("Burger"))
        {
            return;
        }

        if (playerHolding.currentIngredient == null)
        {
            return;
        }


        switch (playerHolding.currentIngredient.ingredientData.ingredient)
        {
            case GameTypes.Ingredient.RawMeat:
                StartCookingObject();
                ingredientToConvertTo = cookedMeat;
                break;
            default:
                break;
        }
    }
}
