using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    // M�todo que se llama cuando el jugador presiona el bot�n "Play"
    public void PlayGame()
    {
        // Cambia a la siguiente escena (aseg�rate de que esta escena est� a�adida en el Build Settings)
        SceneManager.LoadScene("SampleScene");
    }

    // M�todo que se llama cuando el jugador presiona el bot�n "Exit"
    public void ExitGame()
    {
        // Sale del juego
        Application.Quit();

        // En el editor de Unity, para probar esto, tambi�n puedes agregar:
        // UnityEditor.EditorApplication.isPlaying = false;
        // Esto detendr� el juego en el editor.
    }
}