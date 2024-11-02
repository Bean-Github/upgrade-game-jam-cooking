using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHolding : MonoBehaviour
{
    public GameObject heldObject;
    public Transform holdingLocation;
    public Ingredient currentIngredient;

    public bool inStation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !inStation)
        {
            DropIngredient();
        }
    }

    public bool TryAddIngredient(GameObject ingredientToAdd)
    {
        if (heldObject == null)
        {
            //GameObject newObject = Instantiate(ingredientToAdd, holdingLocation.position, Quaternion.identity, holdingLocation);
            
            ingredientToAdd.transform.position = holdingLocation.position;
            ingredientToAdd.transform.parent = holdingLocation;

            heldObject = ingredientToAdd;
            heldObject.transform.localScale = Vector3.one;

            currentIngredient = heldObject.GetComponent<Ingredient>();
            
            return true;
        }
        return false;
    }

    public bool TryAddIngredient(GameObject ingredientToAdd, IngredientScriptableObject addedData)
    {
        if (heldObject == null)
        {
            GameObject newObject = Instantiate(ingredientToAdd, holdingLocation.position, Quaternion.identity, holdingLocation);

            newObject.GetComponent<Ingredient>().ingredientData = addedData;

            heldObject = newObject;
            heldObject.transform.localScale = Vector3.one;

            currentIngredient = newObject.GetComponent<Ingredient>();

            return true;
        }
        return false;
    }

    public void DropIngredient()
    {
        Rigidbody2D rb = heldObject.AddComponent<Rigidbody2D>();
        rb.velocity = GetComponent<Rigidbody2D>().velocity;

        heldObject.transform.parent = null;
        heldObject.transform.localScale = Vector3.one;

        heldObject = null;
        currentIngredient = null;
    }


    public void DropIngredient(Transform transformToDropTo)
    {
        if (heldObject != null)
        {
            if (transformToDropTo != null)
            {
                heldObject.transform.position = transformToDropTo.position;
            }

            heldObject.transform.parent = transformToDropTo;
            heldObject.transform.localScale = Vector3.one;

            heldObject = null;
            currentIngredient = null;
        }
    }

    public void DropIngredient(Action<GameObject> execute)
    {
        if (heldObject != null)
        {
            execute(heldObject);

            heldObject = null;
            currentIngredient = null;
        }
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Station"))
        {
            inStation = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Station"))
        {
            inStation = false;
        }
    }

}
