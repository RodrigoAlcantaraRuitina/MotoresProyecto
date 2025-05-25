using UnityEngine;

public class LLave : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AbrirPuerta puerta = FindObjectOfType<AbrirPuerta>();
            if (puerta != null)
            {
                puerta.abrirP = true;
            }

            Destroy(gameObject); // Destruye la llave tras recogerla
        }
    }
}
