using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float vida;

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
