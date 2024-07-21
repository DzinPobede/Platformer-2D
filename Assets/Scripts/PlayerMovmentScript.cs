using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    [SerializeField] private TrailRenderer trailRenderer;
    [SerializeField] private GameOverScreen gameOverScreen;


    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 18f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    public float maxPosition = 0;

    public Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("GroundCheck");
    }
    
    // Update is called once per frame
    void Update()
    {

        if (isDashing)
        {
            return;
        }

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

        //DASH
        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {

            StartCoroutine(Dash());
        }

        if(transform.position.x > maxPosition)
        {
            maxPosition = transform.position.x;
        }
    }
    private void FixedUpdate()
    {
        if(isDashing)
        {
            return;
        }
    }
    private IEnumerator Dash()
    {
        canDash = true;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x *dashingPower, 0f);
        trailRenderer.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        trailRenderer.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            transform.position = new Vector3(-8.22f, -4, 0);
            rb.velocity = new Vector2(0, 0);
            GetComponent<PlayerHealth>().health--;
        }
        
    }
}


