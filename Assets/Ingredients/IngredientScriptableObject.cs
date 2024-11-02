using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "NewIngredient", menuName = "Ingredient")]
public class IngredientScriptableObject : ScriptableObject
{
    public string ingredientName;

    public GameObject ingredientRenderer;

    public GameTypes.Ingredient ingredient;

    public IngredientScriptableObject ingredientToBecome;

    //public GameTypes.CookingStation compatibleStation;

    //public GameTypes.CookingStation stationToTakeFrom;
}
