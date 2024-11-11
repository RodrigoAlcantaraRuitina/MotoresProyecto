using UnityEngine;

public class ataque : MonoBehaviour
{
    [SerializeField] private float velocidad;

    [SerializeField] private float da�o;

    private void Start()
    {
        // Destruye el objeto "Bala" despu�s de 3 segundos
        Destroy(gameObject, 3f);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.CompareTag("Player"))
        {
            Other.GetComponent<vida>().TomarDa�o(da�o);
        }
    }
}
