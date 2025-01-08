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
    void Start()
    {
        targetPoint = 0;
        InvokeRepeating("Disparar", 0f, cadencia);
    }

     private void Disparar()
    {
        // Instancia la bala en la posici�n y rotaci�n del controladorDisparo
        Instantiate(ataque, controladorDisparo.position, controladorDisparo.rotation);
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

    
}
