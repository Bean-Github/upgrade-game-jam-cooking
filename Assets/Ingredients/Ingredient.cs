using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public IngredientScriptableObject ingredientData;

    public MeshFilter ingredientMeshFilter;

    // Start is called before the first frame update
    void Start()
    {
        ingredientMeshFilter.mesh = ingredientData.ingredientMesh;
        ingredientMeshFilter.GetComponent<MeshRenderer>().materials = ingredientData.ingredientMaterials;
    }

    private void Update()
    {

    }

    public void PlaceInsideSomething()
    {
        Destroy(GetComponent<Rigidbody2D>());

        transform.localScale = Vector3.one;

        transform.localRotation = Quaternion.identity;

        foreach (var boxCollider in GetComponents<Collider2D>())
        {
            boxCollider.enabled = false;
        }
        foreach (var boxCollider in GetComponentsInChildren<Collider2D>())
        {
            boxCollider.enabled = false;
        }
    }


    public void DropInWorld()
    {
        Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>();

        rb.drag = 2f;
        rb.gravityScale = 3f;

        rb.angularDrag = 3f;

        transform.localScale = Vector3.one;

        foreach (var boxCollider in GetComponents<Collider2D>())
        {
            boxCollider.enabled = true;
        }
        foreach (var boxCollider in GetComponentsInChildren<Collider2D>())
        {
            boxCollider.enabled = true;
        }
    }


    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") )
        {
            if (transform.parent == null && Input.GetKey(KeyCode.E))
            {
                if (collision.GetComponent<PlayerHolding>().TryAddIngredient(this.gameObject))
                {
                }
            }

            collision.GetComponent<PlayerHolding>().isTouchingWorldIngredient = true;

        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHolding>().isTouchingWorldIngredient = false;
        }
    }


}
