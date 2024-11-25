using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    // Método que se llama cuando el jugador presiona el botón "Play"
    public void PlayGame()
    {
        // Cambia a la siguiente escena (asegúrate de que esta escena esté añadida en el Build Settings)
        SceneManager.LoadScene("SampleScene");
    }

    // Método que se llama cuando el jugador presiona el botón "Exit"
    public void ExitGame()
    {
        // Sale del juego
        Application.Quit();

        // En el editor de Unity, para probar esto, también puedes agregar:
        // UnityEditor.EditorApplication.isPlaying = false;
        // Esto detendrá el juego en el editor.
    }
}