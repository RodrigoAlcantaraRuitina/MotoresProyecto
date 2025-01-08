using UnityEngine;

public class final : MonoBehaviour
{
    // Método llamado al detectar una colisión
    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto que colisiona tiene el tag "Player"
        if (collision.collider.CompareTag("Player"))
        {
            // Cerrar la aplicación
            Debug.Log("Jugador detectado. Cerrando la aplicación...");
            Application.Quit();
        }
    }
}