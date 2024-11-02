using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerStation : MonoBehaviour
{
    public GameObject objectToHold;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                PlayerHolding holding = collision.GetComponent<PlayerHolding>();

                if (holding.TryAddIngredient(objectToHold))
                {
                    
                }
            }
        }
    }
}
