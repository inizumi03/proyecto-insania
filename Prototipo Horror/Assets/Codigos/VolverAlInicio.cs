using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolverAlInicio : MonoBehaviour
{
    public Transform posicionDestino; // Objeto vac�o que define la posici�n espec�fica a la que se mover� el jugador

    // Detectar cuando el jugador entra en el collider de retorno
    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entra al collider es el jugador
        if (other.CompareTag("Jugador") && posicionDestino != null)
        {
            // Teletransportar al jugador a la posici�n del objeto vac�o
            other.transform.position = posicionDestino.position;
        }
    }
}
