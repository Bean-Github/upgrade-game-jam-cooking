using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerCheckerStation : MonoBehaviour
{
    public PlayerHolding playerHolding;
    
    private bool playerInTrigger;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (playerHolding)
            {

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
