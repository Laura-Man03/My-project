using System;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float jumpForce = 4f;

    private float moveDirection;

    private Rigidbody2D playerRb;

    //public int maxHealth = 100;
    public int Health = 100;

    public int currentHealth = 0;
    //int currentHealth = 1;
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
        //currentHealth = maxHealth;
    }
    

    // ---- Fixed Update for movement ----
    void FixedUpdate()
    {
        //left to right movement
        playerRb.linearVelocityX = moveDirection * moveSpeed;
        
    }
        // ---- Damage ----
        private void OnTriggerEnter(Collider other)
        {
            if (CompareTag("Enemy"))
            {
                Damage(10);
            }
        }
          
        private void Damage(int value)
        {
            Health -= value;
        }
        
        // ---- Health ----
        
        //how do i make the health display show the damage? 
        //i need to take the value of damage and display it when use
        //health collectable to heal player. enemy takes away 10, 
        //health pack gives 10 displaying that
        public void ChangeHealth(int amount)
        {
            //currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
            //currentHealth cannot be set to a value that is over or below 0
            
            //healthText.text = $"<b>Health</b>: {currentHealth}";
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

    private void OnJump(InputValue value)
    {
        //ensures that jump stays constant
        playerRb.linearVelocityY = jumpForce;
    }
    
   
}
