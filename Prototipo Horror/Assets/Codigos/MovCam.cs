using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCam : MonoBehaviour
{
    public float sensibilidadMouse = 100f;   // Sensibilidad del mouse
    private float rotacionX = 0f;            // Control de la rotación vertical (eje X)

    void Start()
    {
        // Bloquear el cursor en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Capturar el movimiento del mouse
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadMouse * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadMouse * Time.deltaTime;

        // Actualizar la rotación vertical y limitarla para evitar que gire completamente
        rotacionX -= mouseY;
        rotacionX = Mathf.Clamp(rotacionX, -90f, 90f);  // Limitar el ángulo de rotación en el eje X

        // Aplicar la rotación vertical a la cámara (eje X)
        transform.localRotation = Quaternion.Euler(rotacionX, 0f, 0f);

        // Rotar el objeto padre (jugador) en el eje Y (horizontal) con el mouse
        transform.parent.Rotate(Vector3.up * mouseX);
    }
}
