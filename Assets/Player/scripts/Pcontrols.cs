using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
public class Pcontrols : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is create
    private ThirdPersonActionAsset actions;
    private InputAction move;
    private Rigidbody rb;
    [SerializeField]
    public float movementForce;
    [SerializeField]
    private float maxSpeed = 10f;
    [SerializeField]
    private Vector3 ForceDirection = Vector3.zero;
    [SerializeField]
    private Camera playerCamera;
    [SerializeField] 
    SpriteRenderer spriterenderer;
    [SerializeField]
    GameObject hitbox;
    [SerializeField] 
    Animator animator;
    [SerializeField] 
    InputActionAsset inputActions;
    private float xPosLastFrame = 0f;
    public bool isOnGround = true;
    public float cooldownTime = 2f;
    private float nextFireTime = 0f;
    public static int noOfClicks = 0;
    float lastClickedTime = 0;
    float maxComboDelay = 1;
    float horizontalInput = 0f;
    public float jumpForce = 10f;
    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        actions = new ThirdPersonActionAsset();
    }

    private void OnEnable()
    {
        move = actions.Player.Move;    
        actions.Player.Enable();
    }
    private void OnDisable()
    {
        actions.Player.Disable();
    }

    private void FixedUpdate()
    {
        walkanim();
        
        //ForceDirection += move.ReadValue<Vector2>().x * getCameraRight(playerCamera) * movementForce;
        //ForceDirection += move.ReadValue<Vector2>().y * getCameraForward(playerCamera) * movementForce;
        //rb.AddForce(ForceDirection, ForceMode.Impulse);
        //ForceDirection = Vector3.zero;
        horizontalInput = Input.GetAxis("Horizontal");
        flipCharacterx();

        if (animator.GetBool("attacking") == false)
        {
 transform.Translate(Vector3.right * Time.deltaTime * movementForce * horizontalInput * 2);
        }
           
        
        //LookAt();


     
    }

    private void flipCharacterx()
    {
        if (move.ReadValue<Vector2>().x == 1)
        {
            spriterenderer.flipX = false;
            hitbox.transform.localPosition = new Vector3(1,0,0);
            
        }
        else if (move.ReadValue<Vector2>().x == -1)
        {
            spriterenderer.flipX = true;
            hitbox.transform.localPosition = new Vector3(-1 , 0,0);

        }

        xPosLastFrame = transform.position.x;
    }

    private void walkanim()
    {
        float moving = move.ReadValue<Vector2>().x;
        if (moving != 0)
        {
            animator.SetBool("isrunning", true);
        } else
        {
            animator.SetBool("isrunning", false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

}

