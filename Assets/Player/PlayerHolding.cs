using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHolding : MonoBehaviour
{
    public GameObject heldObject;
    public Transform holdingLocation;
    public Ingredient currentIngredient;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool TryAddIngredient(GameObject ingredientToAdd)
    {
        if (heldObject == null)
        {
            GameObject newObject = Instantiate(ingredientToAdd, holdingLocation.position, Quaternion.identity, holdingLocation);
            
            heldObject = newObject;

            currentIngredient = newObject.GetComponent<Ingredient>();
            
            return true;
        }
        return false;
    }

}
