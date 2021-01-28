using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;

    float directionX = 0.0f;
    float runSpeed = 5.0f;
    float jumpSpeed = 7.0f;

    bool isJumping = false;
    bool facingRight;

    private void Start()
    {
        facingRight = true;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        /*
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * runSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-Vector2.right * runSpeed * Time.deltaTime);
        }
        */
        directionX = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(directionX));
        Flip(directionX);
        Jump();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(directionX, rb.velocity.y);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isJumping == false)
        {
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            animator.SetBool("Jump", true);
            isJumping = true;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Debug.Log("Collides with deathzone");
            animator.SetBool("Jump", false);
            isJumping = false;
        }
    }

    void Flip(float directionX)
    {
        if(directionX > 0 && !facingRight || directionX < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 playerScale = transform.localScale;
            playerScale.x *= -1;
            transform.localScale = playerScale;
        }
    }
}
