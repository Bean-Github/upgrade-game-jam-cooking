using System.Collections;
using System.Collections.Generic;
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
