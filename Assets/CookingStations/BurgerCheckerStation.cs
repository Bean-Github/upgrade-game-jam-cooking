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



                    if (ingredientsToMatch.Equals(heldBurger.ingredients))
                    {
                        playerHolding.ResetHeldObject();
                    }
                    else
                    {
                        
                    }
                    Destroy(heldBurger);
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
