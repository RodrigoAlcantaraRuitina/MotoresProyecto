using UnityEngine;

public class pinchos : MonoBehaviour
{

    [SerializeField] private int da�o;
    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.CompareTag("Player"))
        {
            Other.GetComponent<vida>().TomarDa�o(da�o);
        }
    }
}
