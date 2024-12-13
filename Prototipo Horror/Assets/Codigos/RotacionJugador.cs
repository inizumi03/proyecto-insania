using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionJugador : MonoBehaviour
{
    public Transform camara;           // Referencia a la c�mara del jugador
    public float suavizadoGiro = 0.1f; // Suavizado para el giro del jugador

    private float velocidadGiro;       // Para el suavizado de rotaci�n

    void Update()
    {
        // Obtener la rotaci�n en el eje Y de la c�mara
        float rotacionY = camara.eulerAngles.y;

        // Suavizar la rotaci�n del jugador hacia la misma direcci�n que la c�mara
        float rotacionSuavizada = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotacionY, ref velocidadGiro, suavizadoGiro);

        // Aplicar la rotaci�n al jugador solo en el eje Y
        transform.rotation = Quaternion.Euler(0f, rotacionSuavizada, 0f);
    }
}
