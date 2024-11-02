using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHolding : MonoBehaviour
{
    public GameObject currentIngredient;
    public Transform holdingLocation;

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
        if (currentIngredient == null)
        {
            Instantiate(ingredientToAdd, holdingLocation.position, Quaternion.identity, holdingLocation);
            return true;
        }
        return false;
    }

}
