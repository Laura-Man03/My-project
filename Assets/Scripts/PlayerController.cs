using System;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float jumpForce = 4f;
    public LayerMask WhatIsGround;
    
    private float moveDirection;
    public bool isGrounded;
    //later add when have animations ^
    private Rigidbody2D playerRb;
    
    public int currentHealth;
    public int MaxHealth = 100;
    
    public TMP_Text healthText;
    
    //private SpriteRenderer spriteRenderer;
    // commenting sprite stuff for now
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        ChangeHealth(MaxHealth);
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }
    

    // ---- Fixed Update for movement ----
    void FixedUpdate()
    {
        //left to right movement
        playerRb.linearVelocityX = moveDirection * moveSpeed;
        
        GroundCheck();
    }
    
        // ---- Damage ----
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
        }
        
        private void Damage(int amount)
        {
            ChangeHealth(currentHealth - amount);
        }
        
        // ---- Health ----
        
        public void ChangeHealth(int newHealth)
        {
            //making sure health stays between 0 and maximum
            currentHealth = Mathf.Clamp(newHealth, 0, MaxHealth);
            healthText.text = $"<b>Energy</b>: {currentHealth}";
        }
        
    
    // ---- Movement ----
    private void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        moveDirection = input.x;
        //if (input.x != 0)
       // {
       //     spriteRender.flipX = (input.x < 0);
       // }
    }

    // ---- Jump ----
    private void OnJump(InputValue value)
    {
        //ensures that jump stays constant
        playerRb.linearVelocityY = jumpForce;
    }
    
    private void GroundCheck()
    {
        RaycastHit2D hit  = Physics2D.BoxCast(transform.position, Vector2.one * 0.1f, 0, Vector2.down, 0.2f, WhatIsGround.value);
        
        isGrounded = hit.collider != null;
    }
   
}
