using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] private float velocidad;

    [SerializeField] private float daño;

    private void Start()
    {
        // Destruye el objeto "Bala" después de 3 segundos
        Destroy(gameObject, 3f);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D Other) 
    {
      if (Other.CompareTag("Enemigo"))
        {
            Other.GetComponent<Enemigo>().TomarDaño(daño);
            Destroy(gameObject);
        }
    }
   
}
