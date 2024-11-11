using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float vida;

    public void TomarDa�o(float da�o)
    {
        vida -= da�o;
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
        // Aqu� puedes agregar efectos o animaciones adicionales para una muerte espec�fica por pisot�n
        Destroy(gameObject);
    }
}
