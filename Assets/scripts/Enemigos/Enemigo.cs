using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float vida;
    //[SerializeField] private int vida;
    [SerializeField] private float cantidadPuntos;

    [SerializeField] private Puntaje puntaje;


    void Start() 
    {
       
    }

    public void TomarDaño(float daño)
    {
        vida -= daño;
        if (vida <= 0)

        {
            Muerte();
            puntaje.SumarPuntos(cantidadPuntos);
        }

    }


    private void Muerte()
    {
        Destroy(gameObject);
    }

}
