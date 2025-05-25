using UnityEngine;

public class AbrirPuerta : MonoBehaviour
{
    public bool abrirP = false;
    private Animator animator;

    private void Start()
    {
        abrirP = false;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (abrirP)
        {
            animator.SetTrigger("Abrir");
            abrirP = false; // Evita repetir el trigger
        }
    }
}