using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CookingStation : MonoBehaviour
{
    public GameObject storedObject;
    public IngredientScriptableObject ingredientToConvertTo;

    public PlayerHolding playerHolding;

    public Transform storedObjectLocation;

    public bool doneCooking;

    public GameObject ingredientBlueprint;

    public float cookTime;
    public Slider progressSlider;

    private bool touchingPlayer;


    protected void Start()
    {
        progressSlider.maxValue = cookTime;

        doneCooking = false;
    }

    private void Update()
    {
        // Pick up cooked object
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (doneCooking)
            {
                PlayerPickupBehavior();
            }
        }
    }

    public virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            touchingPlayer = true;

            // Inserts object into cooking
            if (Input.GetKey(KeyCode.E))
            {
                if (storedObject == null)
                {
                    PlayerInsertBehavior();
                }
            }

            // Cooking behavior
            if (storedObject != null && !doneCooking)
            {
                progressSlider.gameObject.SetActive(true);

                if (Input.GetKey(KeyCode.E))
                {
                    progressSlider.value += Time.fixedDeltaTime;
                }
                else
                {
                    ResetSlider();
                }
            }

            // Finish Cooking
            if (progressSlider.value >= cookTime && storedObject != null)
            {
                FinishCookingObject();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            touchingPlayer = false;
            ResetSlider();
        }
    }


    public virtual void PlayerInsertBehavior() 
    {

    }

    public virtual void PlayerPickupBehavior()
    {
        playerHolding.TryAddIngredient(storedObject);
        storedObject = null;
        doneCooking = false;
    }

    protected void StartCookingObject()
    {
        playerHolding.DropIngredient(storedObjectLocation);

        storedObject = storedObjectLocation.GetChild(0).gameObject;

        storedObject.transform.up = -transform.forward;
    }

    // Changes displayed object
    protected void FinishCookingObject()
    {
        Destroy(storedObject);

        ResetSlider();

        storedObject = Instantiate(
            ingredientBlueprint,
            storedObjectLocation.position,
            Quaternion.identity,
            storedObjectLocation
        );

        storedObject.transform.up = -transform.forward;

        storedObject.GetComponent<Ingredient>().ingredientData = ingredientToConvertTo;

        doneCooking = true;
    }

    protected void ResetSlider()
    {
        progressSlider.gameObject.SetActive(false);
        progressSlider.value = 0f;
    }

}







