using UnityEngine;
using UnityEngine.SceneManagement;

public class vida : MonoBehaviour
{
    [SerializeField] private float hp;

    public void TomarDaño(float daño)
    {
        hp -= daño;
        if (hp <= 0)
        {
            Muerte();
        }
    }

    private void Muerte()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
