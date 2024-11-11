using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;      // Objeto a seguir
    public float smoothSpeed = 0.125f;  // Velocidad de seguimiento
    public Vector3 offset;               // Desplazamiento de la c�mara

    void LateUpdate()
    {
        if (player != null) // Asegura que el jugador est� asignado
        {
            // Posici�n deseada con desplazamiento
            Vector3 desiredPosition = player.transform.position + offset;
            // Suavizado del movimiento de la c�mara
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
