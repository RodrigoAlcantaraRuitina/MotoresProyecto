using UnityEngine;

public class pisoton : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D colisionadorEnemigo)
    {
        if (colisionadorEnemigo.CompareTag("Enemigo"))
        {
            Enemigo enemigo = colisionadorEnemigo.GetComponent<Enemigo>();
            if (enemigo != null)
            {
                enemigo.MuerteAplastar(); // Llama al nuevo método MuerteAplastar
            }
        }
    }
}
