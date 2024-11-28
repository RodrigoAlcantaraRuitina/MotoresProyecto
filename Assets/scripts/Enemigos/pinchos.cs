using UnityEngine;

public class pinchos : MonoBehaviour
{

    [SerializeField] private float daño;
    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.CompareTag("Player"))
        {
            Other.GetComponent<vida>().TomarDaño(daño);
        }
    }
}
