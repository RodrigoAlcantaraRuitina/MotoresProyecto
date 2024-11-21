using UnityEngine;

public class plataformasY : MonoBehaviour
{
    public Transform[] patrolPoints; // Puntos de patrullaje
    public int targetPoint; // Índice del punto objetivo actual
    public float speed; // Velocidad de movimiento

    void Start()
    {
        targetPoint = 0; // Inicia en el primer punto
    }

    void Update()
    {
        // Salir si no hay puntos de patrullaje
        if (patrolPoints.Length == 0) return;

        // Fijar la posición en x, moviéndose solo en y
        Vector2 targetPosition = new Vector2(transform.position.x, patrolPoints[targetPoint].position.y);

        // Mover hacia el siguiente punto en el eje y
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Si alcanza el punto en y, avanzar al siguiente
        if (Mathf.Abs(transform.position.y - targetPosition.y) < 0.1f)
        {
            targetPoint = (targetPoint + 1) % patrolPoints.Length;
        }
    }
}