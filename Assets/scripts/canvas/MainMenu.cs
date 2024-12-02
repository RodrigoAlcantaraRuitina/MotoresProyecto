using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Método para iniciar el juego
    public void PlayGame()
    {
        // Carga la escena del juego (asegúrate de que la escena esté en Build Settings)
        SceneManager.LoadScene("Prototipo");
    }

    // Método para salir del juego
    public void QuitGame()
    {
        Debug.Log("Salir del juego."); // Solo para pruebas (no se verá en el build final)
        Application.Quit(); // Salir del juego (solo funciona en builds, no en el editor)
    }
}
