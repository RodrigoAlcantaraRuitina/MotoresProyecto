using UnityEngine;

public class Enemigo2 : MonoBehaviour
{
    //enemigo que disparara
    [SerializeField] private float vida;

    public void TomarDaño(float daño)
    {
        vida -= daño;
        if (vida <= 0)

        {
            Muerte();
        }

    }


    private void Muerte()
    {
        Destroy(gameObject);
    }

    public void MuerteAplastar()
    {
        // Aquí puedes agregar efectos o animaciones adicionales para una muerte específica por pisotón
        Destroy(gameObject);
    }
}
