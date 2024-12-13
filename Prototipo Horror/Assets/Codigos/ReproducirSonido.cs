using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReproducirSonido : MonoBehaviour
{
    public AudioSource sonido;         // AudioSource que reproducir� el sonido
    public float duracionSonido = 3f;  // Duraci�n en segundos para detener el sonido

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entra en el collider es el jugador
        if (other.CompareTag("Jugador") && sonido != null)
        {
            // Reproducir el sonido
            sonido.Play();

            // Iniciar corrutina para detener el sonido despu�s de un tiempo
            StartCoroutine(DetenerSonidoDespuesDeTiempo());
        }
    }

    private IEnumerator DetenerSonidoDespuesDeTiempo()
    {
        // Esperar el tiempo definido
        yield return new WaitForSeconds(duracionSonido);

        // Detener el sonido
        if (sonido != null)
        {
            sonido.Stop();
        }
    }
}
