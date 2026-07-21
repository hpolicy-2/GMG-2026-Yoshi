using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Vector2 input = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );

        animator.SetBool("IsMoving", input != Vector2.zero);
    }
}