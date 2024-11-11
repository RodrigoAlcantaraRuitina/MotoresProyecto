using System.Collections; // Asegúrate de incluir esto
using UnityEngine;

public class DashMovimiento : MonoBehaviour
{
    public float alcance = 5f;      // Distancia que recorre el dash
    public float duracionDash = 0.2f; // Tiempo que tarda en completar el dash (modificable desde el inspector)
    public float cooldownDash = 1f;  // Tiempo de espera entre dashes

    private bool puedeDash = true;   // Si el dash está disponible
    private float ultimaVezDash = -Mathf.Infinity; // Última vez que se usó el dash
    private Vector3 puntoFinal;      // Posición final del dash

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); // Obtener el input horizontal ('A' o 'D')

        // Verificar si el dash está disponible tras el cooldown
        if (Time.time >= ultimaVezDash + cooldownDash)
        {
            puedeDash = true;
        }

        // Activar el dash si se presiona W y hay input horizontal
        if (Input.GetKeyDown(KeyCode.W) && puedeDash && horizontal != 0)
        {
            Vector3 direccionDash = new Vector3(horizontal, 0, 0).normalized;  // Dirección del dash
            puntoFinal = transform.position + direccionDash * alcance;  // Calcular el punto final
            StartCoroutine(RealizarDash());
        }
    }

    // Corrutina para ejecutar el dash suavemente
    private IEnumerator RealizarDash()
    {
        puedeDash = false;  // Deshabilitar el dash temporalmente
        ultimaVezDash = Time.time;  // Registrar el momento del dash

        Vector3 puntoInicial = transform.position;  // Guardar la posición inicial
        float tiempoTranscurrido = 0;  // Tiempo acumulado del movimiento

        // Mover el objeto suavemente desde el punto inicial al punto final
        while (tiempoTranscurrido < duracionDash)
        {
            transform.position = Vector3.Lerp(puntoInicial, puntoFinal, tiempoTranscurrido / duracionDash);
            tiempoTranscurrido += Time.deltaTime;  // Incrementar el tiempo en cada frame
            yield return null;  // Esperar al siguiente frame
        }

        transform.position = puntoFinal;  // Asegurar que el personaje llegue exactamente al punto final
    }
}