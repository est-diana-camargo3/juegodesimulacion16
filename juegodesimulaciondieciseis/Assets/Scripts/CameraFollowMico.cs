using UnityEngine;

public class CameraFollowMico : MonoBehaviour
{
    public Transform micoTransform; // Asigna aquí al personaje en el inspector
    public float smoothSpeed = 0.125f;
    public Vector3 offset; // Ajustar si se quiere que la cámara no esté justo encima

    public float minX; // Límite izquierdo (inicio del escenario)
    public float maxX; // Límite derecho (final del escenario)

    private float lastCameraX; // Para evitar que retroceda

    void Start()
    {
        lastCameraX = transform.position.x;
    }

    void LateUpdate()
    {
        float desiredX = micoTransform.position.x + offset.x;

        // No retroceder
        desiredX = Mathf.Max(desiredX, lastCameraX);

        // Limitar a los bordes del escenario
        desiredX = Mathf.Clamp(desiredX, minX, maxX);

        // Nueva posición de la cámara
        Vector3 desiredPosition = new Vector3(desiredX, transform.position.y + offset.y, transform.position.z + offset.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;

        // Actualiza la última posición de la cámara
        lastCameraX = transform.position.x;
    }
}
