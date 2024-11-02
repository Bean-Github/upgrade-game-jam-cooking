using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "NewIngredient", menuName = "Ingredient")]
public class IngredientScriptableObject : ScriptableObject
{
    public string ingredientName;

    public Mesh ingredientMesh;

    public GameTypes.Ingredient ingredient;
}
