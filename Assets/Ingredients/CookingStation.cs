using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingStation : MonoBehaviour
{
    public virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInsideBehavior();
        }
    }

    public virtual void PlayerInsideBehavior()
    {

    }
}
