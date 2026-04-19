using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 8f;

    [Header("Jump")]
    public float jumpForce = 12f;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    [Header("Ground Check")]
    public Transform groundCheckPoint;

    private Rigidbody2D rb;
    private bool isGrounded;

    public Animator animator;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    public void Move(float moveInput)
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        animator.SetFloat("move", Mathf.Abs(moveInput));
        Flip();
    }

    private void Flip()
    {
        if(rb.linearVelocity.x > 0.1f)
            transform.localScale = new Vector3(1, 1, 1);
        else if (rb.linearVelocity.x < -0.1f)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    public void Jump()
    {
        if (!isGrounded) return;
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        //rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }
    private void Update()
    {
        CheckGround();
    }
    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheckPoint.position,
            groundCheckRadius,
            groundLayer
        );
    }

    // ================= DEBUG =================

    private void OnDrawGizmosSelected()
    {
        if (groundCheckPoint == null) return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheckPoint.position, groundCheckRadius);
    }
}
