using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerCheckerStation : MonoBehaviour
{
    public PlayerHolding playerHolding;


    public List<IngredientScriptableObject> ingredientsToMatch;


    public ParticleSystem losePSystem;

    private bool playerInTrigger;


    // Start is called before the first frame update
    void Start()
    {
        playerInTrigger = false;
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

                    //List<IngredientScriptableObject> compareList = new List<IngredientScriptableObject>();

                    // Check match
                    bool matches = true;

                    if (heldBurger.ingredients.Count != ingredientsToMatch.Count)
                    {
                        matches = false;
                    }
                    else
                    {
                        for (int i = 0; i < heldBurger.ingredients.Count; i++)
                        {
                            if (heldBurger.ingredients[i].ingredientData.name != ingredientsToMatch[i].name)
                            {
                                matches = false;
                            }
                        }                        
                    }

                    // Win or lose
                    if (matches)
                    {
                        WinGame();
                    }
                    else
                    {
                        DontWinGame();
                    }

                    Destroy(heldBurger.gameObject);
                    playerHolding.ResetHeldObject();
                }
            }

        }

    }


    private void WinGame()
    {

    }

    private void DontWinGame()
    {
        losePSystem.Play();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInTrigger = false;
        }
    }

}
