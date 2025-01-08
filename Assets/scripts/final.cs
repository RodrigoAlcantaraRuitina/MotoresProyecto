using UnityEngine;

public class final : MonoBehaviour
{
    // M�todo llamado al detectar una colisi�n
    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto que colisiona tiene el tag "Player"
        if (collision.collider.CompareTag("Player"))
        {
            // Cerrar la aplicaci�n
            Debug.Log("Jugador detectado. Cerrando la aplicaci�n...");
            Application.Quit();
        }
    }
}