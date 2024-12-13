using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class DesvioCamara : MonoBehaviour
{
    public GameObject camara;

    bool mover;

    public float limTempMover, limTempEleccion;
    float tempMover, tempEleccion;

    public float sensibilidadMouse = 250f;   // Sensibilidad del mouse
    private float rotacionX = 0f;            // Control de la rotación vertical (eje X)

    int x, y;

    private void OnDisable()
    {
        mover = false;
        tempMover = 0f;
    }

    void Update()
    {
        ActivarMovimiento();
        EleccionDeMovimiento();
        MovimientoDeCamara();
    }

    void MovimientoDeCamara()
    {
        if (mover)
        {
            float mouseX = x * sensibilidadMouse * Time.deltaTime;
            float mouseY = y * sensibilidadMouse * Time.deltaTime;

            // Actualizar la rotación vertical y limitarla para evitar que gire completamente
            rotacionX -= mouseY;
            rotacionX = Mathf.Clamp(rotacionX, -45f, 45);  // Limitar el ángulo de rotación en el eje X

            // Aplicar la rotación vertical a la cámara (eje X)
            //camara.transform.localRotation = Quaternion.Euler(rotacionX, mouseX, 0f);

            //camara.transform.localRotation = Quaternion.Euler(rotacionX, 0f, 0f);

            // Rotar el objeto padre (jugador) en el eje Y (horizontal) con el mouse
            camara.transform.parent.Rotate(Vector3.up * mouseX);

            // Rotar el objeto padre (jugador) en el eje Y (horizontal) con el mouse
            //camara.transform.parent.Rotate(Vector3.up * mouseX);
        }
    }

    void EleccionDeMovimiento()
    {
        if (mover)
        {
            if (tempEleccion < limTempEleccion)
                tempEleccion += Time.deltaTime;
            else
            {
                tempEleccion = 0;

                x = Random.Range(-1, 2);
                y = Random.Range(-1, 2);
            }
        }
    }

    void ActivarMovimiento()
    {
        if (gameObject.activeSelf)
        {
            if (tempMover < limTempMover)
                tempMover += Time.deltaTime;
            else
            {
                tempMover = 0;
                mover = !mover;
            }
        }
    }
}
