using UnityEngine;
using UnityEngine.SceneManagement;


public class vida : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth { get; private set; } 

    private void Start()
    {
        currentHealth = maxHealth;
    }
    public void TomarDaño(int daño)
    {
        currentHealth -= daño;
        if (currentHealth <= 0)
        {
            Muerte();
        }
    }

    private void Muerte()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
