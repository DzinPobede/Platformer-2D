using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovmentScript : MonoBehaviour
{
    private float speed = 5f;
    private float jumpPower = 7f;
    private bool isGrounded = false;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private float groundCheckRadius = 0.2f;

    public Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("GroundCheck");
    }
    
    // Update is called once per frame
    void Update()
    {
        //MOVMENT
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2 (moveInput * speed, rb.velocity.y);

        //JUMPING
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            animator.SetTrigger("IsJumping 0");
        }

        //TESTING IS GOUNDED
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    
        //ANIMATION FOR MOVING
        animator.SetFloat("Speed", Mathf.Abs(moveInput));

        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1,1, 1); 
        }
        else if(moveInput < 0)
        {
            transform.localScale = new Vector3 (-1,1,1);
        }


        //ANIMATION FOR ATTACK
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("IsAttacking 0");
        }


    }
}
