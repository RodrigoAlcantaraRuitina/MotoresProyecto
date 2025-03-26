using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class BarraEnergia : MonoBehaviour
{
    public Image rellenoBarraVida;
    private Invisbilidad energiaJugador; // Referencia al script Invisbilidad

    private float valorBarraActual; // Valor actual de la barra de energía (para interpolación)
    public float velocidadTransicion = 5f; // Velocidad con la que se llena/descarga la barra

    void Start()
    {
        energiaJugador = FindObjectOfType<Invisbilidad>(); // Encuentra el script en la escena
        valorBarraActual = (float)energiaJugador.energia / 10f; // Inicializa el valor actual
    }

    void Update()
    {
        if (energiaJugador != null)
        {
            // Calcula el valor objetivo
            float valorObjetivo = (float)energiaJugador.energia / 10f;

            // Interpola suavemente entre el valor actual y el objetivo
            valorBarraActual = Mathf.Lerp(valorBarraActual, valorObjetivo, velocidadTransicion * Time.deltaTime);

            // Actualiza el fillAmount de la barra de energía
            rellenoBarraVida.fillAmount = valorBarraActual;
        }
    }
}

