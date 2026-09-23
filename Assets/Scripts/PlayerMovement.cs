using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public enum PlayerStates { Idle, Walking, Jumping };
    public PlayerStates state;

    string dir;

    public bool inAir;

    [Header("Movement Boundaries")]
    public float minX = -12f;

    [Header("Jump Force")]
    public float jumpStrength = 50f;
    public float walkSpeed = 10f;

    [Header("Ground Check Settings")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;

    [Header("Rigidbody")]
    Rigidbody2D rb;
    public bool isGrounded;


    private void Start()
    {
        Time.timeScale = 1f;
        rb = GetComponent<Rigidbody2D>();
        state = PlayerStates.Idle;
    }

    void Update()
    {



       


        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);


        // horizontal movement — preserve vertical velocity so jumping isn't cancelled
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            dir = "R";
            state = PlayerStates.Walking;
            rb.velocity = new Vector2(walkSpeed, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            dir = "L";
            state = PlayerStates.Walking;
            rb.velocity = new Vector2(-walkSpeed, rb.velocity.y);
        }
        else
        {
            if (!inAir) state = PlayerStates.Idle;
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        } 
        
        transform.position = new Vector3
        (
            Mathf.Clamp(transform.position.x, minX, Mathf.Infinity),
            transform.position.y,
            transform.position.z
        );

        Debug.Log("Grounded: " + isGrounded);
        Debug.Log("Update running");

    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
        state = PlayerStates.Jumping;
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) 
            return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }


}



