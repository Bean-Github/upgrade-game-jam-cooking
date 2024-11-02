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
    }

    private void Update()
    {

    }

    public void PlaceInsideSomething()
    {
        Destroy(GetComponent<Rigidbody2D>());

        transform.localScale = Vector3.one;

        transform.localRotation = Quaternion.identity;

        foreach (var boxCollider in GetComponents<BoxCollider2D>())
        {
            boxCollider.enabled = false;
        }
    }


    public void DropInWorld()
    {
        Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>();

        rb.drag = 2f;

        transform.localScale = Vector3.one;

        foreach (var boxCollider in GetComponents<BoxCollider2D>())
        {
            boxCollider.enabled = true;
        }
    }


    public void OnTriggerStay2D(Collider2D collision)
    {
        if (transform.parent == null && collision.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            if (collision.GetComponent<PlayerHolding>().TryAddIngredient(this.gameObject))
            {
            }
        }
    }


}
