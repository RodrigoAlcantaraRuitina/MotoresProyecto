using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour//manten ùlsado controly doble r para cambiar el nombre de forma seguro

{

    private float horizontal;
    private float speed = 16f;  //12f original
    private float speedIndetectable = 36f;  //12f original
    private float jumpingPower = 18f;   //16f original
    private bool isFacingRight = true;

    private bool canDoubleJump;

    private bool isWallSliding;
    private float wallSlidingSpeed = 0f;

    private bool isWallJumping;
    private float wallJumpingDirection;
    //private float wallJumpingTime = 0.2f;
    private float wallJumpingCounter;
    public float wallJumpDuration = 0.4f;
    public Vector2 wallJumpForce = new Vector2(8f, 16f);
    public Vector2 jumpFall;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    private float maxHorizontalSpeed = 20f;
    private float maxVerticalSpeed = 25f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;

    private Invisibilidad invisibilidad; // Referencia al script de invisibilidad

    private Animator animator; //cambio


    void Start()
    {
        invisibilidad = GetComponent<Invisibilidad>(); // Buscar el componente en el mismo GameObject
        animator = GetComponent<Animator>(); //cambio
    }
    void Update()
    {
        if (isDashing)
        {
            return;
        }

        horizontal = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Horizontal", Mathf.Abs(rb.linearVelocity.x)); //cambio
        animator.SetBool("deslizando", isWallSliding); //cambio
        animator.SetBool("disponibleDash", canDash); //cambio

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded())
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
                canDoubleJump = true;
            }
            else if (isWallSliding)
            {
                WallJump();
            }
            else if (canDoubleJump)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
                canDoubleJump = false;
                animator.SetTrigger("dobleSalto"); //cambio
            }
        }

        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
            animator.SetTrigger("dashDis"); //cambio
        }

        WallSlide();

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

        if (!isWallJumping)
        {
            //rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);//original
            float currentSpeed = invisibilidad.indetectable ? speedIndetectable : speed;
            rb.linearVelocity = new Vector2(horizontal * currentSpeed, rb.linearVelocity.y);
    }

        LimitVelocity();

        if (isGrounded())
        {
            canDoubleJump = true;
        }

        if (isWallSliding)
        {
            canDoubleJump = true;
        }
        animator.SetBool("enSuelo", isGrounded()); //cambio
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }



    private bool IsWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }

    public void WallSlide()
    {
        if (IsWalled() && !isGrounded() && horizontal != 0f)
        {
            isWallSliding = true;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Clamp(rb.linearVelocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
        }
    }

    public void WallJump()
    {
        isWallJumping = true;
        wallJumpingDirection = -transform.localScale.x;

        rb.linearVelocity = new Vector2(wallJumpingDirection * wallJumpForce.x, wallJumpForce.y);
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y + jumpFall.y);
        // Desactiva temporalmente el control horizontal
        horizontal = 0f;

        Invoke(nameof(StopWallJumping), wallJumpDuration);

        if (transform.localScale.x != wallJumpingDirection)
        {
            Flip();
        }
    }

    private void StopWallJumping()
    {
        isWallJumping = false;
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f) //para el enemigo modificar cuando se mueve
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x = isFacingRight ? Mathf.Abs(localScale.x) : -Mathf.Abs(localScale.x);
            transform.localScale = localScale;
        }
    }

    public IEnumerator Dash()
    {
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

    private void LimitVelocity()
    {
        rb.linearVelocity = new Vector2(
            Mathf.Clamp(rb.linearVelocity.x, -maxHorizontalSpeed, maxHorizontalSpeed),
            Mathf.Clamp(rb.linearVelocity.y, -maxVerticalSpeed, maxVerticalSpeed)
        );
    }
}