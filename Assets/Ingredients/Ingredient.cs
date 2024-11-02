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


    public void OnTriggerStay2D(Collider2D collision)
    {
        if (transform.parent == null && collision.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            if (collision.GetComponent<PlayerHolding>().TryAddIngredient(this.gameObject))
            {
                Destroy(GetComponent<Rigidbody2D>());
            }
        }
    }


}
