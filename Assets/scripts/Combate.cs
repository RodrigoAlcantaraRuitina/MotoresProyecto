using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Combate : MonoBehaviour
{
    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float dañoGolpe;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Golpe();
        }
    }
    private void Golpe() 
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);
        
        foreach (Collider2D colisionador in objetos) 
        {
            if (colisionador.CompareTag("Enemigo")) 
            {
            colisionador.transform.GetComponent<Enemigo>().TomarDaño(dañoGolpe);
            }
        }
    
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }
}
