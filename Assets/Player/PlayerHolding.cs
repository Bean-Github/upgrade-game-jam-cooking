using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

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
        if (heldObject == null)
        {
            if (ingredientToAdd.CompareTag("Burger"))
            {
                if (ingredientToAdd.transform.childCount == 1)
                {
                    GameObject burger = ingredientToAdd;
                    ingredientToAdd = ingredientToAdd.transform.GetChild(0).gameObject;
                    Destroy(burger);
                } else
                {
                    ingredientToAdd.transform.position = holdingLocation.position;
                    ingredientToAdd.transform.parent = holdingLocation;
                    ingredientToAdd.transform.localScale = Vector3.one;

                    heldObject = ingredientToAdd;

                    currentIngredient = null;

                    return true;
                }

            }

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
        if (heldObject == null) return;

        if (heldObject.CompareTag("Burger"))
        {
            Burger burger = heldObject.GetComponent<Burger>();
            burger.drop();
            heldObject.transform.parent = null;

            heldObject = null;
            currentIngredient = null;
        } else
        {
            heldObject.GetComponent<Ingredient>().DropInWorld();
            heldObject.transform.parent = null;

            heldObject = null;
            currentIngredient = null;
        }
    }

    public void DropIngredient(Transform transformToDropTo)
    {
        if (heldObject == null) return;

        heldObject.transform.position = transformToDropTo.position;

        heldObject.transform.parent = transformToDropTo;

        heldObject.GetComponent<Ingredient>().PlaceInsideSomething();

        ResetHeldObject();
    }

    public void DropIngredient(Action<GameObject> execute)
    {
        if (heldObject != null && !heldObject.CompareTag("Burger"))
        {
            execute(heldObject);

            ResetHeldObject();
            //heldObject.GetComponent<Ingredient>().PlaceInsideSomething();
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
