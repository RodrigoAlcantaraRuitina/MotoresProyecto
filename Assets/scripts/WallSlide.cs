using UnityEngine;

public class WallSlide : MonoBehaviour
{
    public float slideSpeed = 2f; // Velocidad del deslizamiento
    private Rigidbody2D rb;

    private bool tocandoPared = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (tocandoPared && rb.linearVelocity.y < 0) // Solo desliza hacia abajo
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, -slideSpeed); // Controlar la ca�da
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("pared"))
        {
            tocandoPared = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("pared"))
        {
            tocandoPared = false;
        }
    }
}