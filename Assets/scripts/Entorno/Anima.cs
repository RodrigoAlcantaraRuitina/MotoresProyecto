using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Anima : MonoBehaviour
{
    //[SerializeField] private GameObject efecto;

    [SerializeField] private float cantidadPuntos;

    [SerializeField] private Puntaje puntaje;



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            puntaje.SumarPuntos(cantidadPuntos);
            //Instantiate(efecto, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

