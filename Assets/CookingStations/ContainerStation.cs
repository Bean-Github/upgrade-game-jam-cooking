using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerStation : MonoBehaviour
{
    public IngredientScriptableObject ingredientDataToHold;

    public GameObject ingredientBlueprint;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                PlayerHolding holding = collision.GetComponent<PlayerHolding>();

                if (holding.isTouchingWorldIngredient)
                {
                    return;
                }

                if (holding.TryAddIngredient(ingredientBlueprint, ingredientDataToHold))
                {
                    // If add is successful
                }
                else
                {
                    // If not successful
                }
            }
        }

    }
}
