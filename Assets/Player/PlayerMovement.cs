using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Values")]
    public float maxMovementSpeed;
    public float airMaxMovementSpeed;
    public float jumpForce;

    public float acceleration;
    public float deceleration;


    [Header("References")]
    public Rigidbody2D rb;
    public Grounded grounded;


    private float m_CurrMoveVel;
    private float m_CurrMaxMoveSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    float xInput;
    // Update is called once per frame
    void FixedUpdate()
    {
        xInput = Input.GetAxisRaw("Horizontal");

        // Accelerate
        m_CurrMoveVel = Mathf.Clamp(
            xInput * acceleration * Time.fixedDeltaTime + m_CurrMoveVel, 
            -m_CurrMaxMoveSpeed, 
            m_CurrMaxMoveSpeed
        );

        // Decelerate
        if (Mathf.Abs(xInput) == 0f)
        {
            m_CurrMoveVel = Mathf.MoveTowards(m_CurrMoveVel, 0f, deceleration * Time.fixedDeltaTime);
        }

        // While Grounded
        if (grounded.IsGrounded)
        {
            GroundedBehavior();
        }
        // Mid Air
        else
        {
            MidAirBehavior();
        }
    }


    private void GroundedBehavior()
    {
        if (m_PreJump)
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }

        m_CurrMaxMoveSpeed = maxMovementSpeed;

        rb.position += Vector2.right * m_CurrMoveVel * Time.fixedDeltaTime;
    }

    private bool m_PreJump;
    private void MidAirBehavior()
    {
        m_CurrMaxMoveSpeed = airMaxMovementSpeed;

        rb.position += Vector2.right * m_CurrMoveVel * Time.fixedDeltaTime;

        if (Input.GetKey(KeyCode.Space))
        {
            StartCoroutine(JumpDampTimer());
        }
    }

    private void Jump()
    {
        grounded.IsGrounded = false;
        rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        rb.velocity = Vector3.up * jumpForce;
    }

    private IEnumerator JumpDampTimer()
    {
        m_PreJump = true;
        yield return new WaitForSeconds(0.5f);
        m_PreJump = false;  
    }
}
