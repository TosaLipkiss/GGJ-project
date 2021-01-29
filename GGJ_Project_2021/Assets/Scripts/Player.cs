using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;

    float directionX = 0.0f;
    float runSpeed = 5.0f;
    float jumpSpeed = 7.0f;

    public Text scoreText;
    public float score = 5;

    bool isJumping = false;
    bool facingRight;

    private void Start()
    {
        Score();
        facingRight = true;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
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
            isJumping = true;
            if (rb.velocity.y > 0)
            {
                animator.SetBool("Jump", true);
            }
            else
            {
                animator.SetBool("Fall", true);
            }
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("Collides with deathzone");
            animator.SetBool("Jump", false);
            isJumping = false;
        }

        if(collision.gameObject.tag == "Points")
        {
            Debug.Log("Point picked up");
            Destroy(gameObject);
            Score();
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

    public void Score()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
