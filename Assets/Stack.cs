using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    private float topPos;
    public PlayerHolding playerHolding;
    private GameObject burger;
    private bool isEmpty;
    private bool actionTriggered;
    private bool playerInTrigger;

    void Start()
    {
        topPos = 0f;
        initBurger();
        isEmpty = true;
        actionTriggered = false;
        playerInTrigger = false;
    }

    void Update()
    {
        if (playerInTrigger)
        {
            if (Input.GetKey(KeyCode.E) && !actionTriggered)
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

    private void initBurger()
    {
        float height = GetComponent<MeshFilter>().mesh.bounds.size.y;
        float center = GetComponent<MeshFilter>().mesh.bounds.center.y;

        burger = new GameObject("Burger");
        burger.AddComponent<Burger>();
        burger.tag = "Burger";
        burger.transform.parent = this.gameObject.transform;
        burger.transform.position = this.gameObject.transform.position + (center) * Vector3.up;
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
            actionTriggered = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInTrigger = true;
            actionTriggered = false;
        }
    }

    bool hasFirstItem;

    public void handleStack(GameObject obj)
    {
        if (obj == null || obj.CompareTag("Burger")) return;

        GameObject c = obj.transform.GetChild(0).gameObject;

        Mesh mr = c.GetComponent<MeshFilter>().mesh;
        Bounds bounds = mr.bounds;
        Vector3 size = bounds.size;
        Vector3 center = bounds.center;

        Vector3 offset = new Vector3(0, topPos + size.z - center.z, 0);
        topPos += size.z - center.z;

        obj.transform.parent = burger.transform;
        obj.transform.position = burger.transform.position + offset;
        obj.transform.localScale = Vector3.one;
        obj.transform.up = -Vector3.forward;

        Ingredient ing = obj.GetComponent<Ingredient>();

        switch (ing.ingredientData.ingredient)
        {
            case GameTypes.Ingredient.Bun:
                if (!hasFirstItem)
                {
                    obj.transform.up *= -1;
                }
                else
                {
                    obj.transform.position -= Vector3.up * 0.3f;
                }
                break;

            case GameTypes.Ingredient.Lettuce:
                obj.transform.position -= Vector3.up * 0.8f;
                break;

            case GameTypes.Ingredient.Tomato:
                obj.transform.position -= Vector3.up * 0.7f;
                break;

            case GameTypes.Ingredient.Onion:
                obj.transform.position -= Vector3.up * 0.95f;
                break;

            case GameTypes.Ingredient.RawMeat:
                obj.transform.position -= Vector3.up * 0.05f;
                break;
                
            case GameTypes.Ingredient.CookedMeat:
                obj.transform.position -= Vector3.up * 0.05f;
                break;

            default:
                break;
        }

        burger.GetComponent<Burger>().ingredients.Add(ing);
        hasFirstItem = true;
        isEmpty = false;
    }

    public void handleRemove()
    {
        burger.transform.position -= Vector3.up * transform.childCount * 0.5f;
        burger.transform.rotation = Quaternion.identity;
        playerHolding.TryAddIngredient(burger);

        topPos = 0f;
        initBurger();
        hasFirstItem = false;
        isEmpty = true;
    }
}
