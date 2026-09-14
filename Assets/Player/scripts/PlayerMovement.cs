using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    [Header("Movement")]
    public float moveSpeed = 5f;
    float horizontalMovement;

    [Header("Jumping")]
    public float jumpPower = 10f;
    public int maxJumps = 1;
    private int jumpsRemaining;

    [Header("GroundCheck")]
    public Transform groundCheckPos;
    public Vector2 groundCheckSize = new Vector2(0.49f, 0.03f);
    public LayerMask groundLayer;

    [Header("Gravity")]
    public float baseGravity = 2f;
    public float maxFallSpeed = 18f;
    public float fallGravityMult = 2f;
    private PlayerInput inputActions;
    [SerializeField]
    Animator animator;
    [SerializeField]
    SpriteRenderer SPR;
    [SerializeField]
    GameObject hitbox;
    private void Start()
    {
        inputActions = GetComponent<PlayerInput>();
    }
    void Update()
    {

        if (animator.GetBool("attacking") == true)
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            
        }
        else if (animator.GetBool("attacking") == false)
        {
            rb.linearVelocity = new Vector2(horizontalMovement * moveSpeed, rb.linearVelocity.y);
           
        }
           

        //falling gravity
        if (rb.linearVelocity.y < 0)
        {
            rb.gravityScale = baseGravity * fallGravityMult; //fall faster and faster
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Max(rb.linearVelocity.y, -maxFallSpeed)); //max fall speed
            animator.SetBool("Falling", true);
        }
        else
        {
            rb.gravityScale = baseGravity;
        }

        GroundCheck();
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (animator.GetBool("attacking") == false)
        {
            if (context.ReadValue<Vector2>().x == -1)
            {
                //SPR.flipX = true;
                transform.localScale = new Vector2(1, 1);

            }
            else if (context.ReadValue<Vector2>().x == 1)
            {
               // SPR.flipX = false;
                transform.localScale = new Vector2(-1, 1);
            }

            animator.SetBool("isrunning", true);
            horizontalMovement = context.ReadValue<Vector2>().x;
        }
        if (context.canceled){
        Debug.Log("canceled");
            horizontalMovement = 0;
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            animator.SetBool("isrunning", false);
        }


        
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (jumpsRemaining > 0)
        {
            if (context.performed)
            {
                //Hold down jump button = full height
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
                animator.SetTrigger("Jumping");
                jumpsRemaining--;
            }
            else if (context.canceled && rb.linearVelocity.y > 0)
            {
                //Light tap of jump button = half the height
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
                animator.SetBool("Falling", true);
                jumpsRemaining--;
            }
        }
    }

    private void GroundCheck()
    {
        if (Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, groundLayer)) //checks if set box overlaps with ground
        {
           jumpsRemaining = maxJumps;
            animator.SetBool("Falling", false);
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        //Ground check visual
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(groundCheckPos.position, groundCheckSize);
    }

    public bool isOnGround()
    {
        if (Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, groundLayer)) //checks if set box overlaps with ground
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
