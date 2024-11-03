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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!IsGrounded && collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            IsGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            if (gameObject.activeSelf)
            {
                StartCoroutine(FoxTrotTimer());
            }
        }
    }


    private IEnumerator FoxTrotTimer()
    {
        yield return new WaitForSeconds(foxTrotTime);
        IsGrounded = false;
    }
}
