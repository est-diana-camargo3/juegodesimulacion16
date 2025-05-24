using UnityEngine;

public class CameraFollowMicoAvanzada : MonoBehaviour
{
    public Transform micoTransform;
    public float smoothSpeed = 0.125f;
    public Vector3 offset; // Ej: (2, 1, -10)

    public float minX = 0f;
    public float maxX = 100f;
    public float minY = -5f;
    public float maxY = 20f;

    private float lastCameraX;

    void Start()
    {
        lastCameraX = transform.position.x;
    }

    void LateUpdate()
    {
        // 1. Deseada posición de la cámara con offset respecto al mico
        float desiredX = micoTransform.position.x + offset.x;
        float desiredY = micoTransform.position.y + offset.y;

        // 2. Evitar que retroceda (X solo avanza)
        desiredX = Mathf.Max(desiredX, lastCameraX);

        // 3. Limitar dentro del escenario
        desiredX = Mathf.Clamp(desiredX, minX, maxX);
        desiredY = Mathf.Clamp(desiredY, minY, maxY);

        Vector3 desiredPosition = new Vector3(desiredX, desiredY, transform.position.z + offset.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // 4. Mover cámara
        transform.position = smoothedPosition;

        // 5. Actualizar último X si avanzó
        lastCameraX = transform.position.x;

        // 6. Evitar que el mico se salga de la vista
        BloquearMicoFueraDeVista();
    }

    void BloquearMicoFueraDeVista()
    {
        float cameraLeftEdge = transform.position.x - Camera.main.orthographicSize * Camera.main.aspect;

        // Si el mico se sale del borde izquierdo de la cámara, lo bloqueamos ahí
        if (micoTransform.position.x < cameraLeftEdge)
        {
            micoTransform.position = new Vector3(cameraLeftEdge, micoTransform.position.y, micoTransform.position.z);
        }
    }
}
