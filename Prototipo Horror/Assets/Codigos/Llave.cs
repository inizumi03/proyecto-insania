using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llave : MonoBehaviour
{
    public delegate void LlaveDestruida(); // Definición del delegado
    public event LlaveDestruida onLlaveDestruida; // Evento que se dispara cuando la llave se destruye

    public delegate void DesactivarEfecto(int indice);
    static public event DesactivarEfecto desactivar;

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entra en el trigger es el jugador
        if (other.CompareTag("Jugador")) // Asegúrate de que tu jugador tenga la etiqueta "Jugador"
        {
            // Disparar el evento de destrucción de la llave
            onLlaveDestruida.Invoke();
            desactivar.Invoke(ControlEnemigo.indiceDeefectosActivos);

            Destroy(gameObject); // Destruir la llave
        }
    }
}
