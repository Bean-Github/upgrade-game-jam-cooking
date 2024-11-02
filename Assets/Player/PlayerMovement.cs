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

    public float jumpDampTime;

    [Header("References")]
    public Rigidbody2D rb;
    public Grounded grounded;


    private float m_CurrMoveVel;
    private float m_CurrMaxMoveSpeed;
    private float m_CurrJumpDampTimer;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");

        // Accelerate
        m_CurrMoveVel = Mathf.Clamp(
            xInput * acceleration * Time.deltaTime + m_CurrMoveVel, 
            -m_CurrMaxMoveSpeed, 
            m_CurrMaxMoveSpeed
        );

        // Decelerate
        if (Mathf.Abs(xInput) == 0f)
        {
            m_CurrMoveVel = Mathf.MoveTowards(m_CurrMoveVel, 0f, deceleration * Time.deltaTime);
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

    void FixedUpdate()
    {
        rb.velocity = new Vector2(m_CurrMoveVel, rb.velocity.y);
    }


    private void GroundedBehavior()
    {
        m_CurrMaxMoveSpeed = maxMovementSpeed;
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_CurrJumpDampTimer = jumpDampTime;
        }
        CheckJump();
    }
    
    private void MidAirBehavior()
    {
        m_CurrMaxMoveSpeed = airMaxMovementSpeed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_CurrJumpDampTimer = jumpDampTime;
        }
        CheckJump();
    }

    private void Jump()
    {
        grounded.IsGrounded = false;
        rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        rb.velocity = Vector3.up * jumpForce;
    }

    private void CheckJump()
    {
        m_CurrJumpDampTimer = Mathf.Max(m_CurrJumpDampTimer - Time.deltaTime, 0f);
        if (m_CurrJumpDampTimer > 0 && grounded.IsGrounded)
        {
            Jump();
        }
    }
}
