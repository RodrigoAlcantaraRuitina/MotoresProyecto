using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena
public class final : MonoBehaviour
{
    // Método llamado al detectar una colisión 2D
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar si el objeto que colisiona tiene el tag "Player"
        if (collision.collider.CompareTag("Player"))
        {
            // Cargar la escena "menu"
            Debug.Log("Jugador detectado. Cargando la escena 'menu'...");
            SceneManager.LoadScene("menu");
        }
    }
}