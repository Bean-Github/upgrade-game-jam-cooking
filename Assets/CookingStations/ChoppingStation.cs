using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoppingStation : CookingStation
{
    public IngredientScriptableObject choppedLettuce;
    public IngredientScriptableObject choppedTomato;
    public IngredientScriptableObject choppedOnion;

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
            case GameTypes.Ingredient.Lettuce:
                StartCookingObject();
                ingredientToConvertTo = choppedLettuce;
                break;
            case GameTypes.Ingredient.Tomato:
                StartCookingObject();
                ingredientToConvertTo = choppedTomato;
                break;
            case GameTypes.Ingredient.Onion:
                StartCookingObject();
                ingredientToConvertTo = choppedOnion;
                print("HI");
                break;
            default:
                break;
        }
    }
}
