using UnityEngine;

public class TopdownMovement : MonoBehaviour
{
    public float moveSpeed = 4f;

    private Rigidbody2D rb;
    private Animator animator;

    private Vector2 movement;
    private Vector2 lastDirection = Vector2.down;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;

        bool isMoving = movement != Vector2.zero;

        if (isMoving)
        {
            lastDirection = movement;

            animator.SetFloat("MoveX", movement.x);
            animator.SetFloat("MoveY", movement.y);
        }
        else
        {
            animator.SetFloat("MoveX", lastDirection.x);
            animator.SetFloat("MoveY", lastDirection.y);
        }

        animator.SetBool("IsMoving", isMoving);
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}