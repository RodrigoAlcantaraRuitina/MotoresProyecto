using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movimiento : MonoBehaviour
{
    private float horizontal;
    private float speed = 12f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    private bool canDoubleJump;

    private bool isWallSliding;
    private float wallSlidingSpeed = 10f;
    //private float originalGravityScale;

    private bool isWallJumping;
    private float wallJumpingDirection;
    private float wallJumpingTime = 0.2f;
    private float wallJumpingCounter;
    //private float wallJumpingDuration = 0.4f;
    //private Vector2 wallJumpingPower = new Vector2(8f, 16f);
    public float wallJumpDuration;
    public Vector2 wallJumpForce;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;

    //private void Start()
    //{
    //originalGravityScale = rb.gravityScale;
    //}

    void Update()
    {
        if (isDashing)
        {
            return;
        }

        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded())
            {
                // Primer salto
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
                canDoubleJump = true; // Permitir el doble salto
            }
            if (isWallSliding) 
            {
            isWallJumping = true;
                Invoke("StopWallJumping", wallJumpDuration);
            }
            else if (canDoubleJump)
            {
                // Doble salto
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
                canDoubleJump = false; // Ya no puede hacer doble salto
            }
        }

        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

        WallSlide();
        WallJump();

        if (!isWallJumping)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {

        if (isDashing)
        {
            return;
        }

        //if (!isWallJumping)
        //{
            //rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
        //}
        if (isWallJumping) 
        {
            rb.linearVelocity = new Vector2(-horizontal * wallJumpForce.x, wallJumpForce.y);
        }
        else 
        {
            rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
        }
        if (isGrounded())
        {
            canDoubleJump = true;
        }

        if (isWallSliding)
        {
            canDoubleJump = true; // Restablecer el doble salto al deslizarse por una pared
        }
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private bool IsWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }
    private void WallSlide()
    {
        if (IsWalled() && !isGrounded() && horizontal != 0f)
        {
            isWallSliding = true;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Clamp(rb.linearVelocity.y, -wallSlidingSpeed, float.MaxValue));
            //rb.gravityScale = originalGravityScale * 0.1f;
        }
        else
        {
            isWallSliding = false;
            //rb.gravityScale = originalGravityScale;
        }

    }

    private void WallJump()
    {
        if (isWallSliding)
        {
            isWallJumping = false;
            wallJumpingDirection = -transform.localScale.x;
            wallJumpingCounter = wallJumpingTime;

            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Jump") && wallJumpingCounter > 0f)
        {
            isWallJumping = true;
            //rb.linearVelocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpingCounter = 0f;

            if (transform.localScale.x != wallJumpingDirection)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }

            //Invoke(nameof(StopWallJumping), wallJumpingDuration);
        }
    }

    private void StopWallJumping()
    {
        isWallJumping = false;
    }
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x = isFacingRight ? Mathf.Abs(localScale.x) : -Mathf.Abs(localScale.x);
            transform.localScale = localScale;
        }
    }

    private IEnumerator Dash()
    {
        Debug.Log($"Dashing! FacingRight: {isFacingRight}, Power: {dashingPower}");

        canDash = false;
        isDashing = true;

        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;

        rb.linearVelocity = new Vector2((isFacingRight ? 1 : -1) * dashingPower, 0f);

        yield return new WaitForSeconds(dashingTime);

        rb.gravityScale = originalGravity;
        isDashing = false;

        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}