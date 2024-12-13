using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muro : MonoBehaviour
{
    public List<GameObject> llaves; // Lista de llaves necesarias para abrir el muro
    private int llavesRecogidas = 0; // Contador de llaves recogidas

    void Start()
    {
        foreach (GameObject llave in llaves)
        {
            if (llave != null)
            {
                // Suscribirse al evento de destrucción de cada llave
                llave.GetComponent<Llave>().onLlaveDestruida += RegistrarLlaveRecogida;
            }
        }
    }

    // Método que se llama cada vez que una llave es destruida
    void RegistrarLlaveRecogida()
    {
        llavesRecogidas++;

        // Verificar si todas las llaves han sido recogidas
        if (llavesRecogidas >= llaves.Count)
        {
            DestruirMuro();
        }
    }

    // Método para destruir el muro
    void DestruirMuro()
    {
        Destroy(gameObject); // Destruir el muro
    }
}
