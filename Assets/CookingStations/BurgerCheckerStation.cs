using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerCheckerStation : MonoBehaviour
{
    public PlayerHolding playerHolding;


    public List<IngredientScriptableObject> ingredientsToMatch;


    private bool playerInTrigger;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInTrigger)
        {
            if (playerHolding.heldObject == null)
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (playerHolding.heldObject.CompareTag("Burger"))
                {
                    Burger heldBurger = playerHolding.heldObject.GetComponent<Burger>();

                    List<IngredientScriptableObject> compareList = new List<IngredientScriptableObject>();

                    foreach (Ingredient item in heldBurger.ingredients)
                    {
                        compareList.Add(item.ingredientData);
                    }

                    if (ingredientsToMatch.Equals(heldBurger.ingredients))
                    {

                    }
                    else
                    {
                        
                    }

                    Destroy(heldBurger.gameObject);
                    playerHolding.ResetHeldObject();
                }
            }

        }

    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInTrigger = true;
        }
    }

}
