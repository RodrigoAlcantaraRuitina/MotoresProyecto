using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena
public class final : MonoBehaviour
{
    // M�todo llamado al detectar una colisi�n 2D
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