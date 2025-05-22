using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DroneMovimiento : MonoBehaviour
{
    [SerializeField] private float velocidad;

    [SerializeField] private Transform controladorSuelo;

    [SerializeField] private float distancia;

    [SerializeField] private bool movimientoDerecha;

    private Rigidbody2D rb;

    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() 
    {
    RaycastHit2D informacionSuelo = Physics2D.Raycast(controladorSuelo.position, Vector2.down, distancia);

        rb.linearVelocity = new Vector2(velocidad, rb.linearVelocity.y);

        if (informacionSuelo == false) 
        {
            Girar();
        }
    }

    private void Girar() 
    {
        movimientoDerecha = !movimientoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        velocidad *= -1;
    }
}
