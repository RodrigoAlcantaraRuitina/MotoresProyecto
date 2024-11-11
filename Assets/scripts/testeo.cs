using UnityEngine;
using UnityEngine.InputSystem;

public class testeo : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de movimiento lateral
    public float fuerzaSalto = 5f; // Fuerza del primer salto
    public float fuerzaSalto2 = 5f; // Fuerza del segundo salto

    private bool enSuelo = true; // Indica si el personaje está en el suelo
    private bool puedeDobleSalto = false; // Controla si puede hacer el segundo salto
    private bool colisionDerecha = false; // Indica si hay colisión a la derecha
    private bool colisionIzquierda = false; // Indica si hay colisión a la izquierda
    private bool mirandoDerecha = true; // Indica si el personaje está mirando a la derecha

    private Rigidbody2D rb; // Referencia al Rigidbody2D

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal > 0 && !colisionDerecha)
        {
            transform.Translate(Vector2.right * horizontal * velocidad * Time.deltaTime);

            // Si se mueve a la derecha y no está mirando a la derecha, gira el sprite
            if (!mirandoDerecha)
            {
                Girar();
            }
        }
        else if (horizontal < 0 && !colisionIzquierda)
        {
            transform.Translate(Vector2.right * horizontal * velocidad * Time.deltaTime);

            // Si se mueve a la izquierda y está mirando a la derecha, gira el sprite
            if (mirandoDerecha)
            {
                Girar();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (enSuelo)
            {
                Saltar(fuerzaSalto);
                puedeDobleSalto = true;
            }
            else if (puedeDobleSalto)
            {
                Saltar(fuerzaSalto2);
                puedeDobleSalto = false;
            }
        }
    }

    void Saltar(float fuerza)
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        rb.AddForce(Vector2.up * fuerza, ForceMode2D.Impulse);
        enSuelo = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("suelo"))
        {
            enSuelo = true;
            puedeDobleSalto = false;
        }

        if (collision.gameObject.CompareTag("pared"))
        {
            Vector2 normal = collision.contacts[0].normal;

            if (normal.x > 0)
                colisionIzquierda = true;
            else if (normal.x < 0)
                colisionDerecha = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("pared"))
        {
            colisionDerecha = false;
            colisionIzquierda = false;
        }
    }

    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha; // Cambiar la orientación
        Vector3 escala = transform.localScale; // Obtener la escala del sprite
        escala.x *= -1; // Invertir la escala en el eje X para voltear el sprite
        transform.localScale = escala; // Asignar la nueva escala
    }
}