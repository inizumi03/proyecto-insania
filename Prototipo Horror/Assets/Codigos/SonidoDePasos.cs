using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoDePasos : MonoBehaviour
{
    public AudioSource audioSource; // Asigna aquí el AudioSource que reproducirá el sonido
    private Vector3 ultimaPosicion; // Para almacenar la última posición del objeto
    private bool estaMoviendose;    // Para rastrear si el objeto está en movimiento

    void Start()
    {
        // Inicializar variables
        ultimaPosicion = transform.position;
        estaMoviendose = false;
    }

    void Update()
    {
        // Comprobar si la posición del objeto ha cambiado
        if (transform.position != ultimaPosicion)
        {
            if (!estaMoviendose)
            {
                // Comenzar a reproducir el sonido si no se está reproduciendo
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

        // Actualizar la última posición
        ultimaPosicion = transform.position;
    }
}
