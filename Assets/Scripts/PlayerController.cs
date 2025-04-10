using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float jumpForce = 4f;

    private float moveDirection;

    private Rigidbody2D playerRb;

    public int maxHealth = 100;
    int currentHealth = 1;
    //made a canvas and TMP to display for player.
    private int score = 0;
    //=====find a way to make the display work!=====
    public TMP_Text scoreText;
    public TMP_Text healthText;
    
    //private SpriteRenderer spriteRenderer;
    // commenting sprite stuff for now
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        //spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
    }
    

    // ---- Fixed Update for movement ----
    void FixedUpdate()
    {
        //left to right movement
        playerRb.linearVelocityX = moveDirection * moveSpeed;
    }
    //==== get enemies to effect health to get a health collectable ====
        // ---- Health ----
        public void ChangeHealth(int amount)
        {
            currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
            //currentHealth cannot be set to a value that is over or below 0
            Debug.Log(currentHealth + " / " + maxHealth);
            healthText.text = $"<b>Health</b>: {currentHealth}";
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
