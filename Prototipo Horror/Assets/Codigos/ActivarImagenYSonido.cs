using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarImagenYSonido : MonoBehaviour
{
    public GameObject imagen;           // Imagen que se activar�
    public AudioSource sonido;          // Sonido que se reproducir�
    public float duracionImagen = 3f;   // Duraci�n en segundos antes de desactivar la imagen y destruir el objeto

    private void Start()
    {
        // Asegurarse de que la imagen est� desactivada al inicio
        if (imagen != null)
        {
            imagen.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entra en el collider es el jugador
        if (other.CompareTag("Jugador"))
        {
            // Activar la imagen
            if (imagen != null)
            {
                imagen.SetActive(true);
            }

            // Reproducir el sonido
            if (sonido != null)
            {
                sonido.Play();
            }

            // Iniciar la corrutina para desactivar la imagen y destruir el objeto
            StartCoroutine(DesactivarYDestruir());
        }
    }

    private IEnumerator DesactivarYDestruir()
    {
        // Esperar la duraci�n definida en duracionImagen
        yield return new WaitForSeconds(duracionImagen);

        // Desactivar la imagen
        if (imagen != null)
        {
            imagen.SetActive(false);
        }

        // Destruir el objeto al que est� asignado este script
        Destroy(gameObject);
    }
}
