using System;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float jumpForce = 2f;
    public LayerMask whatIsGround;
    
    private float moveDirection;
    public bool isGrounded;
    public bool canDoubleJump;
    
    public AudioClip jumpClip;
    
    private Animator animator;
    private AudioSource audioSource;
    private Rigidbody2D playerRb;
    private SpriteRenderer spriteRenderer;
    
    public int currentHealth = 50;
    public int maxHealth = 100;
    
    public TMP_Text healthText;
    public WinScript winScreen;
    public LoseScript loseScreen;
    
    
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        //start at 50
        ChangeHealth(currentHealth);
    }
    

    // ---- Fixed Update ---- //
    void FixedUpdate()
    {
        //left to right movement
        playerRb.linearVelocity = new Vector2(moveDirection * moveSpeed, playerRb.linearVelocity.y);
        GroundCheck();
        //playerRb.linearVelocityX = moveDirection * moveSpeed;
        
        animator.SetBool("Is Grounded", isGrounded);
        animator.SetBool("Is Double Jumping", canDoubleJump == false);
        animator.SetFloat("Velocity Y", playerRb.linearVelocity.y);
        //animator.SetFloat("Velocity Y", playerRb.linearVelocityY);
    }
    
        // ---- Damage ---- //
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                Damage(10);
            }

            if (other.CompareTag("Heal"))
            {
                ChangeHealth(currentHealth + 10);
            }
            
            if (other.CompareTag("Exit"))
            {
                if (currentHealth >= 100)
                {
                    winScreen.StartFade();
                }
                else
                {
                    loseScreen.StartFade();
                }

                gameObject.SetActive(false); // Hide the player
            }
        }
        
        private void Damage(int amount)
        {
            ChangeHealth(currentHealth - amount);
        }
        
        // ---- Health ---- //
        
        public void ChangeHealth(int newHealth)
        {
            //making sure health stays between 0 and maximum
            currentHealth = Mathf.Clamp(newHealth, 0, maxHealth);
            healthText.text = $"<b>Energy</b>: {currentHealth}";
        }
        
    
    // ---- Movement ---- //
    private void OnMove(InputValue value)
    {
        //read the x/y input from the keyboard
        Vector2 input = value.Get<Vector2>();
        moveDirection = input.x;
        if (input.x != 0)
        {
            //do not flip if not pressing key
            spriteRenderer.flipX = (input.x < 0);
        }
        //set the animator boolean to true and false
        animator.SetBool("Is Moving", moveDirection != 0);
    }
    
    private void OnJump(InputValue value)
    {
        
        if (canDoubleJump == true)
        {
            //ensures that the character always jumps at a specific speed
            playerRb.linearVelocityY = jumpForce;
            audioSource.PlayOneShot(jumpClip);
        }
        
        if (isGrounded == false && canDoubleJump)
        {
            canDoubleJump = false;
        }
    
        Debug.Log("Jump!");
    }

    // ---- Ground Check ---- //
    private void GroundCheck()
    {
        RaycastHit2D hit = Physics2D.BoxCast(
            transform.position,
            Vector2.one * 0.1f,
            0,
            Vector2.down,
            12.7f,
            whatIsGround.value
        );
        
        isGrounded = hit.collider != null;
        
        if (isGrounded)
        {
            canDoubleJump = true;
        }
        Debug.Log("Grounded: " + isGrounded);
    }
}
