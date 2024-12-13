using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolverAlInicio : MonoBehaviour
{
    public Transform posicionDestino; // Objeto vacío que define la posición específica a la que se moverá el jugador

    // Detectar cuando el jugador entra en el collider de retorno
    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entra al collider es el jugador
        if (other.CompareTag("Jugador") && posicionDestino != null)
        {
            // Teletransportar al jugador a la posición del objeto vacío
            other.transform.position = posicionDestino.position;
        }
    }
}
