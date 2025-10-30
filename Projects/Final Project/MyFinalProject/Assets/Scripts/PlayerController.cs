using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;      // Movement speed
    private Rigidbody2D rb;           // Reference to Rigidbody2D
    private Vector2 moveInput;        // Player input
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Capture input (Arrow Keys)
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        // Normalize to prevent faster diagonal movement
        moveInput.Normalize();

        if (animator)
        {
            animator.SetFloat("MoveX", moveInput.x);
            animator.SetFloat("MoveY", moveInput.y);
            animator.SetFloat("Speed", moveInput.sqrMagnitude);
        }

        // Flip sprite when moving left
        if (spriteRenderer)
            spriteRenderer.flipX = moveInput.x < 0;
     }

    void FixedUpdate()
    {
        // Apply movement using Rigidbody2D velocity
        rb.linearVelocity = moveInput * moveSpeed;

    }
}
