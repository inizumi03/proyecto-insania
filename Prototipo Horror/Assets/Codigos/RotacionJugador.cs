using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionJugador : MonoBehaviour
{
    public Transform camara;           // Referencia a la cámara del jugador
    public float suavizadoGiro = 0.1f; // Suavizado para el giro del jugador

    private float velocidadGiro;       // Para el suavizado de rotación

    void Update()
    {
        // Obtener la rotación en el eje Y de la cámara
        float rotacionY = camara.eulerAngles.y;

        // Suavizar la rotación del jugador hacia la misma dirección que la cámara
        float rotacionSuavizada = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotacionY, ref velocidadGiro, suavizadoGiro);

        // Aplicar la rotación al jugador solo en el eje Y
        transform.rotation = Quaternion.Euler(0f, rotacionSuavizada, 0f);
    }
}
