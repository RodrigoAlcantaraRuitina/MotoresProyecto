using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float vida;
    //[SerializeField] private int vida;
    public Transform[] patrolPoints;
    public int targetPoint;
    public float speed;

    void Start() 
    {
        targetPoint = 0;
    }

    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);
        if (patrolPoints.Length == 0) return; // Salir si no hay puntos de patrullaje

        // Fijar la posición en y, moviéndose solo en x
        Vector2 targetPosition = new Vector2(patrolPoints[targetPoint].position.x, transform.position.y);

        // Mover hacia el siguiente punto en el eje x
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Si alcanza el punto en x, avanzar al siguiente
        if (Mathf.Abs(transform.position.x - targetPosition.x) < 0.1f)
        {
            targetPoint = (targetPoint + 1) % patrolPoints.Length;
        }
    }
    public void TomarDaño(float daño)
    {
        vida -= daño;
        if (vida <= 0)

        {
            Muerte();
        }

    }


    private void Muerte()
    {
        Destroy(gameObject);
    }

    public void MuerteAplastar()
    {
        // Aquí puedes agregar efectos o animaciones adicionales para una muerte específica por pisotón
        Destroy(gameObject);
    }
}
