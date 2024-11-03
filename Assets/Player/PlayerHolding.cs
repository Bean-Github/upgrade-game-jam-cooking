using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DropIngredient();
        }
    }

    public bool TryAddIngredient(GameObject ingredientToAdd)
    {
        if (heldObject == null && !heldObject.CompareTag("Burger"))
        {
            //GameObject newObject = Instantiate(ingredientToAdd, holdingLocation.position, Quaternion.identity, holdingLocation);
            
            ingredientToAdd.transform.position = holdingLocation.position;
            ingredientToAdd.transform.parent = holdingLocation;

            heldObject = ingredientToAdd;

            currentIngredient = heldObject.GetComponent<Ingredient>();
            currentIngredient.PlaceInsideSomething();

            return true;
        }
        return false;
    }

    public bool TryAddIngredient(GameObject ingredientBlueprint, IngredientScriptableObject addedData)
    {
        if (heldObject == null)
        {
            GameObject newObject = Instantiate(ingredientBlueprint, holdingLocation.position, Quaternion.identity, holdingLocation);

            newObject.GetComponent<Ingredient>().ingredientData = addedData;

            heldObject = newObject;

            currentIngredient = newObject.GetComponent<Ingredient>();
            currentIngredient.PlaceInsideSomething();

            return true;
        }
        return false;
    }

    public void DropIngredient()
    {
        heldObject.GetComponent<Ingredient>().DropInWorld();
        heldObject.transform.parent = null;

        heldObject = null;
        currentIngredient = null;
    }

    public void DropIngredient(Transform transformToDropTo)
    {
        if (heldObject != null)
        {
            heldObject.transform.position = transformToDropTo.position;

            heldObject.transform.parent = transformToDropTo;

            heldObject.GetComponent<Ingredient>().PlaceInsideSomething();

            ResetHeldObject();
        }
    }

    public void DropIngredient(Action<GameObject> execute)
    {
        if (heldObject != null)
        {
            execute(heldObject);

            ResetHeldObject();
            heldObject.GetComponent<Ingredient>().PlaceInsideSomething();
        }
    }

    private void ResetHeldObject()
    {
        heldObject = null;
        currentIngredient = null;
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Station"))
        {
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Station"))
        {
        }
    }

}
