using UnityEngine;
using UnityEngine.SceneManagement;

public class vida : MonoBehaviour
{
    [SerializeField] private float hp;

    public void TomarDa�o(float da�o)
    {
        hp -= da�o;
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
