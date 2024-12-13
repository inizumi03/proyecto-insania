using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MovPlayer : MonoBehaviour
{
    
    public float velocidadMovimiento = 5f;         // Velocidad normal del jugador
    public float velocidadSprint = 10f;             // Velocidad al correr
    public float estaminaMaxima = 100f;             // Cantidad máxima de estamina
    public float regeneracionEstamina = 10f;        // Velocidad de regeneración de estamina por segundo
    public float consumoEstamina = 20f;             // Cantidad de estamina que se gasta por segundo al correr

    private Vector3 velocidadActual;                 // Almacena la velocidad actual
    private Vector3 velocidadDeseada;                // Almacena la velocidad deseada
    private Vector3 velocidadRef;                    // Para la interpolación suave
    public float suavizadoMovimiento = 0.1f;        // Factor de suavizado

    private float estaminaActual;                    // Estamina actual del jugador
    public Image barraEstamina;                      // Imagen de la barra de estamina en el canvas

    void Start()
    {
        estaminaActual = estaminaMaxima;             // Inicializa la estamina
    }

    void Update()
    {
        // Capturar las entradas de movimiento (WASD)
        float movX = Input.GetAxisRaw("Horizontal");  // Movimiento lateral (A/D)
        float movZ = Input.GetAxisRaw("Vertical");    // Movimiento hacia adelante o atrás (W/S)

        // Calcular el vector de movimiento deseado
        Vector3 direccionMovimiento = transform.right * movX + transform.forward * movZ;

        // Determinar si el jugador está corriendo
        bool estaCorriendo = Input.GetKey(KeyCode.LeftShift) && estaminaActual > 0;

        // Cambiar la velocidad según si está corriendo o no
        float velocidadUsada = estaCorriendo ? velocidadSprint : velocidadMovimiento;

        // Calcular la velocidad deseada y aplicar suavizado
        velocidadDeseada = direccionMovimiento.normalized * velocidadUsada;
        velocidadActual = Vector3.SmoothDamp(velocidadActual, velocidadDeseada, ref velocidadRef, suavizadoMovimiento);

        // Aplicar el movimiento al jugador
        transform.position += velocidadActual * Time.deltaTime;

        // Gestionar la estamina
        if (estaCorriendo)
        {
            // Reducir la estamina cuando se corre
            estaminaActual -= consumoEstamina * Time.deltaTime;
            estaminaActual = Mathf.Clamp(estaminaActual, 0f, estaminaMaxima);
        }
        else
        {
            // Regenerar la estamina cuando no se corre
            estaminaActual += regeneracionEstamina * Time.deltaTime;
            estaminaActual = Mathf.Clamp(estaminaActual, 0f, estaminaMaxima);
        }

        // Actualizar la barra de estamina en la UI
        ActualizarBarraEstamina();
    }

    // Método para actualizar la barra de estamina en la UI
    void ActualizarBarraEstamina()
    {
        // Asume que la barra de estamina es una imagen con el "Fill Amount" activado
        barraEstamina.fillAmount = estaminaActual / estaminaMaxima;
    }
}

