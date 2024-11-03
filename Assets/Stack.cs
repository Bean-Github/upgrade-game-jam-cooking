using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    private float topPos;
    public PlayerHolding playerHolding;
    private GameObject burger;
    private bool isEmpty;
    private bool actionTriggered;

    void Start()
    {
        topPos = 0f;
        initBurger();
        isEmpty = true;
        actionTriggered = false;
    }

    private void initBurger()
    {
        float height = GetComponent<MeshRenderer>().bounds.size.y;

        burger = new GameObject("Burger");
        burger.transform.parent = this.gameObject.transform;
        burger.transform.position = this.gameObject.transform.position + height / 2 * Vector3.up;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E) && !actionTriggered)
            {
                actionTriggered = true;

                if (isEmpty || playerHolding.heldObject != null)
                {
                    playerHolding.DropIngredient(handleStack);
                }
                else
                {
                    handleRemove();
                }
            }

            if (Input.GetKeyUp(KeyCode.E))
            {
                actionTriggered = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            actionTriggered = false;
        }
    }

    public void handleStack(GameObject obj)
    {
        if (obj == null) return;

        GameObject c = obj.transform.GetChild(0).gameObject;

        MeshRenderer mr = c.GetComponent<MeshRenderer>();
        Bounds bounds = mr.bounds;
        Vector3 size = bounds.size;

        Vector3 offset = new Vector3(0, topPos + size.y / 2, 0);
        topPos += size.y;

        obj.transform.parent = burger.transform;
        obj.transform.position = burger.transform.position + offset;
        obj.transform.localScale = Vector3.one;

        isEmpty = false;
    }

    public void handleRemove()
    {
        playerHolding.TryAddIngredient(burger);

        topPos = 0f;
        initBurger();
        isEmpty = true;
    }
}
