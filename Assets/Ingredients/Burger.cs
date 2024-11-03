using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burger : MonoBehaviour
{
    public List<Ingredient> ingredients;


    // Start is called before the first frame update
    void Start()
    {
        ingredients = new List<Ingredient>();
    }
    public void drop()
    {
        foreach (var ingredient in ingredients)
        {
            ingredient.GetComponent<Ingredient>().DropInWorld();
            ingredient.transform.parent = null;
        }
        ingredients.Clear();
    }
}
