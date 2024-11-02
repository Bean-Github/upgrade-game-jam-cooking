using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingStation : MonoBehaviour
{
    public PlayerHolding playerHolding;

    public bool canUse;

    public virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E) && canUse)
            {
                PlayerInsideBehavior();
            }
        }
    }

    public virtual void PlayerInsideBehavior()
    {

    }

    private IEnumerator DisableUsage()
    {
        yield return null;
    }
}
