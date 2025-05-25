using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Combate : MonoBehaviour
{
    [SerializeField] public Transform controladorGolpe;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float dañoGolpe;



    private Animator animator; //cambio
    private void Start()
    {
        animator = GetComponent<Animator>(); //cambio
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Golpe();
        }
    }
    private void Golpe() 
    {
        Debug.Log("Golpe"); // ← Registro en consola

        animator.SetTrigger("Atacando");

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
