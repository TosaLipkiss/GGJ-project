using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public AudioClip victoryMusic;
    public AudioClip jumpSound;
    public AudioSource musicSource;
    public AudioSource audioSource;
    public AudioSource truckAudioSource;
    public GameObject victoryScreen;
    Animator animator;
    Rigidbody2D rb;
    public PauseGame pauseGame;
    public TimeScript timeScript;

    float directionX = 0.0f;
    public float runSpeed = 5f;
    float runSpeedMultiplier = 1f;
    float jumpSpeed = 7.0f;

    public Text scoreText;
    public Text victoryScoreText;
    int score = 0;

    bool isJumping = false;
    bool facingRight;

    private void Start()
    {
        Time.timeScale = 1f;
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

        ChangeRunSpeedDuringTime();
        runSpeed = 5.0f - (2.0f * Mathf.Min(Mathf.Max(transform.position.x + 4.0f, 0.0f) / 8.0f, 1.0f));
        runSpeed *= runSpeedMultiplier;

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
            audioSource.PlayOneShot(jumpSound);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Victory")
        {
            musicSource.Stop();
            truckAudioSource.Stop();
            audioSource.Stop();
            audioSource.clip = victoryMusic;
            audioSource.loop = true;
            audioSource.Play();
            victoryScreen.SetActive(true);
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
        victoryScoreText.text = score.ToString();
    }

    void ChangeRunSpeedDuringTime()
    {
        if (timeScript.currentTime < 5f)
        {
            runSpeedMultiplier = 1f;
        }
        else if (timeScript.currentTime < 50f)
        {
            runSpeedMultiplier = 1.6f;
        }
        else if (timeScript.currentTime < 75f)
        {
            runSpeedMultiplier = 1.4f;
        }
        else if (timeScript.currentTime < 100f)
        {
            runSpeedMultiplier = 1.2f;
        }
        else
        {
            runSpeedMultiplier = 1.0f;
        }
    }
}
