using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;      // Objeto a seguir
    public float smoothSpeed = 0.125f;  // Velocidad de seguimiento
    public Vector3 offset;               // Desplazamiento de la cámara

    void LateUpdate()
    {
        if (player != null) // Asegura que el jugador esté asignado
        {
            // Posición deseada con desplazamiento
            Vector3 desiredPosition = player.transform.position + offset;
            // Suavizado del movimiento de la cámara
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
