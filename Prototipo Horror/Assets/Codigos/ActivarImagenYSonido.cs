using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarImagenYSonido : MonoBehaviour
{
    public GameObject imagen;           // Imagen que se activará
    public AudioSource sonido;          // Sonido que se reproducirá
    public float duracionImagen = 3f;   // Duración en segundos antes de desactivar la imagen y destruir el objeto

    private void Start()
    {
        // Asegurarse de que la imagen esté desactivada al inicio
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
        // Esperar la duración definida en duracionImagen
        yield return new WaitForSeconds(duracionImagen);

        // Desactivar la imagen
        if (imagen != null)
        {
            imagen.SetActive(false);
        }

        // Destruir el objeto al que está asignado este script
        Destroy(gameObject);
    }
}
