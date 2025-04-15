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
    
    public int Health = 100;
    public int MaxHealth = 100;
    
    //made a canvas and TMP to display for player.
    private int score = 0;
  
    public TMP_Text scoreText;
    public TMP_Text healthText;
    
    //private SpriteRenderer spriteRenderer;
    // commenting sprite stuff for now
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
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
        private void OnTriggerEnter(Collider other)
        {
            if (CompareTag("Enemy"))
            {
                Damage(10);
            }

            if (other.CompareTag("Heal"))
            {
                Health += 10;
            }
        }
        
        private void Damage(int value)
        {
            ChangeHealth(Health - value);
        }
        
        // ---- Health ----
        
        public void ChangeHealth(int value)
        {
            //making sure health stays between 0 and maximum
            Health = Mathf.Clamp(value, 0, MaxHealth);
            healthText.text = $"<b>Health</b>: {Health}";
        }
      
        //---- Points ----
    public void AddScore(int points)
    {
        score = score + points;
        scoreText.text = $"<b>Score: </b>{score}";
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
