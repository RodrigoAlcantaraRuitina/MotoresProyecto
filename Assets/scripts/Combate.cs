using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Combate : MonoBehaviour
{
    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float dañoGolpe;

    private void Golpe() 
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);
        
        foreach (Collider2D colisionador in objetos) 
        {
            //if (colisionador.compareTag("Enemigo")) 
            //{
            //colisionador.transform.GetComponent<Enemigo>().TomarDaño(dañoGolpe);
            //}
        }
    
    }

    //private void OnDrawGizmos() 
    //{
      //  Gizmos.Color = Color.Red;
        //Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    //}
}
