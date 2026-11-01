using UnityEngine;

public class PlayerOneMovement : MonoBehaviour
{
    public int playerSpeed = 10;
    public float playerJumpPower = 12f;
    public float moveX;
    public bool isGrounded;

    private Rigidbody2D rb;
    private int groundContactCount = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveInput = 0f;
        if (Input.GetKey(KeyCode.A)) moveInput = -1f;
        if (Input.GetKey(KeyCode.D)) moveInput = 1f;

        moveX = moveInput;
        rb.velocity = new Vector2(moveX * playerSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, playerJumpPower);
        isGrounded = false;
        groundContactCount = 0; 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platforms"))
        {
            groundContactCount++;
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platforms"))
        {
            groundContactCount--;

            if (groundContactCount <= 0)
            {
                groundContactCount = 0;
                isGrounded = false;
            }
        }
    }
}
