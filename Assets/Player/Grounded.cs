using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    public float foxTrotTime;

    private bool isGrounded;

    public bool IsGrounded {
        get => isGrounded;
        set
        {
            isGrounded = value;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (gameObject.activeSelf)
        {
            StartCoroutine(FoxTrotTimer());
        }
    }


    private IEnumerator FoxTrotTimer()
    {
        yield return new WaitForSeconds(foxTrotTime);
        IsGrounded = false;
    }
}
