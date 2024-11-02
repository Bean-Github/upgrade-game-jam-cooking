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
            collision.GetComponent<PlayerHolding>().TryAddIngredient(objectToHold);
        }
    }
}
