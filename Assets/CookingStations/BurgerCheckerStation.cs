using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BurgerCheckerStation : MonoBehaviour
{
    public PlayerHolding playerHolding;


    public List<IngredientScriptableObject> ingredientsToMatch;


    public ParticleSystem losePSystem;

    private bool playerInTrigger;

    public GameObject canvasObject;

    private string currentText;

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
                    currentText = "WRONG ORDER";


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

                            if (heldBurger.ingredients[i].ingredientData.ingredient == GameTypes.Ingredient.Lettuce
                                || heldBurger.ingredients[i].ingredientData.ingredient == GameTypes.Ingredient.Tomato
                                || heldBurger.ingredients[i].ingredientData.ingredient == GameTypes.Ingredient.Onion
                                || heldBurger.ingredients[i].ingredientData.ingredient == GameTypes.Ingredient.RawMeat)
                            {
                                currentText = "IT'S RAWW";
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
        GameObject.Find("Manager").GetComponent<GameManager>().Win();
    }

    private void DontWinGame()
    {
        canvasObject.transform.GetComponentInChildren<TextMeshProUGUI>().text = currentText;
        GameObject newObj =  Instantiate(canvasObject, transform);
        newObj.GetComponent<Animator>().Play("BurgerCheckerText");
        Destroy(newObj, 4f);
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
