using UnityEngine;
using UnityEngine.SceneManagement;

public class vida : MonoBehaviour
{
    [SerializeField] private float hp;
    public int maxHealth = 5;
    int currentHealth;

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
