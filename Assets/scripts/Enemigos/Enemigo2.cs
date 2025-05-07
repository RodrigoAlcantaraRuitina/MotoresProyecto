using UnityEngine;

public class Enemigo2 : MonoBehaviour
{
    //enemigo que disparara
    [SerializeField] private float vida;
    public Transform[] patrolPoints;
    public int targetPoint;
    public float speed;
    public float cadencia;
    [SerializeField] private Transform controladorDisparo;
    [SerializeField] private GameObject ataque;


    private bool isFacingRight = true;

    void Start()
    {
        targetPoint = 0;
        //InvokeRepeating("Disparar", 0f, cadencia);
    }

    //private void Disparar()
    //{
    // Instancia la bala en la posici�n y rotaci�n del controladorDisparo
    //      Instantiate(ataque, controladorDisparo.position, controladorDisparo.rotation);
    //    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    public void TomarDa�o(float da�o)
    {
        vida -= da�o;
        if (vida <= 0)

        {
            Muerte();
        }

    }
    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);
        if (patrolPoints.Length == 0) return; // Salir si no hay puntos de patrullaje

        // Fijar la posici�n en y, movi�ndose solo en x
        Vector2 targetPosition = new Vector2(patrolPoints[targetPoint].position.x, transform.position.y);

        // Mover hacia el siguiente punto en el eje x
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Si alcanza el punto en x, avanzar al siguiente
        if (Mathf.Abs(transform.position.x - targetPosition.x) < 0.1f)
        {
            targetPoint = (targetPoint + 1) % patrolPoints.Length;
        }
    }

    private void Muerte()
    {
        Destroy(gameObject);
    }

    //Restar entre la posicion del enemigo(en X) y jugador(en x). Si Jugador es mayor(<0) implica que esta en la derecha, si esta en la izquierda es menor (>0)
}
