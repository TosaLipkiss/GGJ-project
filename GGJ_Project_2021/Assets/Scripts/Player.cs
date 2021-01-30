using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    public PauseGame pauseGame;

    float directionX = 0.0f;
    float runSpeed = 5f;
    float jumpSpeed = 7.0f;

    public Text scoreText;
    int score = 0;

    bool isJumping = false;
    bool facingRight;

    private void Start()
    {
        GetComponent<Rigidbody2D>().gravityScale = 1;
        facingRight = true;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(pauseGame.pause == true || Time.deltaTime == 0)
        {
            return;
        }

        if (transform.position.x < -4)
        {
            runSpeed = 5.0f;
        }
        else if (transform.position.x < -2 && transform.position.x > -4)
        {
            runSpeed = 4.5f;
        }
        else if (transform.position.x < 0 && transform.position.x > -2)
        {
            runSpeed = 3.8f;
        }
        else if (transform.position.x > 0 && transform.position.x < 4)
        {
            runSpeed = 3.2f;
        }
        else if (transform.position.x < 4)
        {
            runSpeed = 3f;
        }

        directionX = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(directionX));
        Flip(directionX);
        Jump();
        Fall();
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
            if (rb.velocity.y > 0f)
            {
                animator.SetBool("Jump", true);
            }
        }
    }

    void Fall()
    {
        if(rb.velocity.y < 0f)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Fall", true);

            if (rb.velocity.y < -0.2f)
            {
                GetComponent<Rigidbody2D>().gravityScale = 5;
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
            animator.SetBool("Fall", false);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Obstacle")
        {
            animator.SetBool("Jump", false);
            isJumping = false;
        }

        if(collision.gameObject.tag == "Points")
        {
            Destroy(collision.gameObject);
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
