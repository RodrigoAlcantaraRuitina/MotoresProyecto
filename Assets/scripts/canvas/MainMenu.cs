using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // M�todo para iniciar el juego
    public void PlayGame()
    {
        // Carga la escena del juego (aseg�rate de que la escena est� en Build Settings)
        SceneManager.LoadScene("Prototipo");
    }

    // M�todo para salir del juego
    public void QuitGame()
    {
        Debug.Log("Salir del juego."); // Solo para pruebas (no se ver� en el build final)
        Application.Quit(); // Salir del juego (solo funciona en builds, no en el editor)
    }
}
