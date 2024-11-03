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
        if (playerHolding.heldObject == null)
        {
            return;
        }

        switch (playerHolding.currentIngredient.ingredientData.ingredient)
        {
            case GameTypes.Ingredient.CookedMeat:
                StartCookingObject();
                ingredientToConvertTo = cookedMeat;
                break;
            default:
                break;
        }
    }
}
