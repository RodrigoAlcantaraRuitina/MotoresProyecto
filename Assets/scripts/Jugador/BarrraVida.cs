using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BarrraVida : MonoBehaviour
{
    public Image rellenoBarraVida;
    private vida vidaJugador; // Referencia al script vida


    void Start()
    {
        vidaJugador = FindObjectOfType<vida>(); // Busca el script vida en la escena  
    }

    // Update is called once per frame
    void Update()
    {
        if (vidaJugador != null)
        {
            rellenoBarraVida.fillAmount = (float)vidaJugador.currentHealth / vidaJugador.maxHealth;
        }
    }

    public void SumarPuntos(float puntosEntrada) 
    {
        puntosEntrada += puntosEntrada;
    }
}
