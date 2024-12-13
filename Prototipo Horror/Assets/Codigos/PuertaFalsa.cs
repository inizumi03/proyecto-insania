using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaFalsa : MonoBehaviour
{
    public GameObject imagenInteractuar; // Imagen que indica que se puede interactuar (se activa al estar cerca)
    public GameObject imagenSusto;      // Imagen del susto que se activa al presionar "E"
    public AudioSource sonidoSusto;     // Sonido que se reproduce al activar el susto
    public float tiempoSusto = 3f;      // Tiempo que la imagen del susto estará activa

    private bool jugadorCerca = false;  // Indica si el jugador está dentro del collider

    void Start()
    {
        // Asegurarse de que ambas imágenes estén desactivadas al inicio
        if (imagenInteractuar != null) imagenInteractuar.SetActive(false);
        if (imagenSusto != null) imagenSusto.SetActive(false);
    }

    void Update()
    {
        // Verificar si el jugador está cerca y presiona la tecla "E"
        if (jugadorCerca && Input.GetKeyDown(KeyCode.E))
        {
            ActivarSusto();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detectar si el jugador entra en el collider
        if (other.CompareTag("Jugador"))
        {
            jugadorCerca = true;

            // Activar la imagen de interacción
            if (imagenInteractuar != null) imagenInteractuar.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Detectar si el jugador sale del collider
        if (other.CompareTag("Jugador"))
        {
            jugadorCerca = false;

            // Desactivar la imagen de interacción
            if (imagenInteractuar != null) imagenInteractuar.SetActive(false);
        }
    }

    private void ActivarSusto()
    {
        // Desactivar la imagen de interacción
        if (imagenInteractuar != null) imagenInteractuar.SetActive(false);

        // Activar la imagen del susto
        if (imagenSusto != null) imagenSusto.SetActive(true);

        // Reproducir el sonido del susto
        if (sonidoSusto != null) sonidoSusto.Play();

        // Desactivar la imagen del susto después de un tiempo
        StartCoroutine(DesactivarSusto());
    }

    private IEnumerator DesactivarSusto()
    {
        // Esperar el tiempo definido
        yield return new WaitForSeconds(tiempoSusto);

        // Desactivar la imagen del susto
        if (imagenSusto != null) imagenSusto.SetActive(false);
    }
}
