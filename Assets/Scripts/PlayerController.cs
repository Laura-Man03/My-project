using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float jumpForce = 4f;

    private float moveDirection;

    private Rigidbody2D playerRb;
    //private SpriteRenderer spriteRenderer;
    // commenting sprite stuff for now
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //left to right movement
        playerRb.linearVelocityX = moveDirection * moveSpeed;
    }

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
