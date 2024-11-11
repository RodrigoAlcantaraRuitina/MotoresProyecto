using UnityEngine;
using UnityEngine.InputSystem;

public class Movimiento : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de movimiento lateral
    public float fuerzaSalto = 5f; // Fuerza del primer salto
    public float fuerzaSalto2 = 5f; // Fuerza del segundo salto
    //public float fuerzaPisoton = 5f; // Fuerza del pisotón

    private bool enSuelo = true; // Indica si el personaje está en el suelo
    private bool puedeDobleSalto = false; // Controla si puede hacer el segundo salto
    private bool colisionDerecha = false; // Indica si hay colisión a la derecha
    private bool colisionIzquierda = false; // Indica si hay colisión a la izquierda
    //private bool puedePisoton = false; // Indica si puede realizar un pisotón

    private Rigidbody2D rb; // Referencia al Rigidbody2D

    void Start()
    {
        // Obtener el componente Rigidbody2D al inicio
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Obtener input horizontal para moverse a la izquierda o derecha
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical"); // Obtener input vertical
        // Verificar si puede moverse en la dirección correspondiente
        if (horizontal > 0 && !colisionDerecha)
        {
            // Mover a la derecha
            transform.Translate(Vector2.right * horizontal * velocidad * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (horizontal < 0 && !colisionIzquierda)
        {
            // Mover a la izquierda
            transform.Translate(Vector2.right * horizontal * -velocidad * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }

        // Saltar si está en el suelo o si puede hacer un doble salto
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (enSuelo)
            {
                Saltar(fuerzaSalto); // Primer salto
                puedeDobleSalto = true; // Habilitar el segundo salto
            }
            else if (puedeDobleSalto)
            {
                Saltar(fuerzaSalto2); // Segundo salto
                puedeDobleSalto = false; // Desactivar el doble salto hasta que vuelva al suelo
            }
           
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //Pisoton(); // Llamar al método para aplicar el pisotón
        }
    }

    // Método para ejecutar el salto
    void Saltar(float fuerza)
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0); // Reiniciar la velocidad vertical
        rb.AddForce(Vector2.up * fuerza, ForceMode2D.Impulse); // Aplicar fuerza hacia arriba
        enSuelo = false; // No está en el suelo mientras está saltando
        //puedePisoton = true; // Puede hacer pisotón al estar en el aire
    }
    void Pisoton()
    {
        //rb.AddForce(Vector2.down * fuerzaPisoton, ForceMode2D.Impulse); // Aplicar fuerza hacia abajo
    }
    // Detectar colisiones con el suelo o con paredes
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("suelo"))
        {
            enSuelo = true; // Está en el suelo
            puedeDobleSalto = false; // Resetear el doble salto
            //puedePisoton = false; // No puede realizar pisotón al estar en el suelo
        }

        // Detectar colisiones a los lados
        if (collision.gameObject.CompareTag("pared"))
        {
            Vector2 normal = collision.contacts[0].normal; // Obtener la dirección de la colisión

            // Si la colisión es desde la derecha (normal hacia la izquierda)
            if (normal.x > 0)
                colisionIzquierda = true;

            // Si la colisión es desde la izquierda (normal hacia la derecha)
            if (normal.x < 0)
                colisionDerecha = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Al salir de la colisión, permitir movimiento de nuevo
        if (collision.gameObject.CompareTag("pared"))
        {
            colisionDerecha = false;
            colisionIzquierda = false;
        }
    }
}