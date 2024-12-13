using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoDePasos : MonoBehaviour
{
    public AudioSource audioSource; // Asigna aqu� el AudioSource que reproducir� el sonido
    private Vector3 ultimaPosicion; // Para almacenar la �ltima posici�n del objeto
    private bool estaMoviendose;    // Para rastrear si el objeto est� en movimiento

    void Start()
    {
        // Inicializar variables
        ultimaPosicion = transform.position;
        estaMoviendose = false;
    }

    void Update()
    {
        // Comprobar si la posici�n del objeto ha cambiado
        if (transform.position != ultimaPosicion)
        {
            if (!estaMoviendose)
            {
                // Comenzar a reproducir el sonido si no se est� reproduciendo
                audioSource.Play();
                estaMoviendose = true;
            }
        }
        else
        {
            if (estaMoviendose)
            {
                // Detener el sonido si el objeto deja de moverse
                audioSource.Stop();
                estaMoviendose = false;
            }
        }

        // Actualizar la �ltima posici�n
        ultimaPosicion = transform.position;
    }
}
