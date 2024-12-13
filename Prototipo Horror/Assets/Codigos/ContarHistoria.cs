using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ContarHistoria : MonoBehaviour
{
    // Lista de mensajes del tutorial
    [TextArea(3, 10)]
    public string[] mensajes;

    // Referencia al componente de texto donde se mostrar� el mensaje
    public Text textoTutorial; // Si usas Text
    // public TMP_Text textoTutorial; // Descomentar si usas TextMeshPro

    // �ndice actual del mensaje
    private int indiceMensaje = 0;

    // Objeto que ser� desactivado cuando el tutorial termine
    public GameObject objetoParaDesactivar;

    // Nombre de la escena a cargar despu�s del tutorial
    public string escenaAFinalizar; // Agregado para definir la escena final

    void Start()
    {
        // Mostrar el primer mensaje si hay mensajes en la lista
        if (mensajes.Length > 0)
        {
            textoTutorial.text = mensajes[indiceMensaje];
        }
    }

    void Update()
    {
        // Detectar clic izquierdo del mouse
        if (Input.GetMouseButtonDown(0))
        {
            MostrarSiguienteMensaje();
        }
    }

    // Funci�n para mostrar el siguiente mensaje en la lista
    void MostrarSiguienteMensaje()
    {
        // Incrementar el �ndice del mensaje
        indiceMensaje++;

        // Si a�n hay mensajes por mostrar
        if (indiceMensaje < mensajes.Length)
        {
            // Mostrar el siguiente mensaje
            textoTutorial.text = mensajes[indiceMensaje];
        }
        else
        {
            // Cuando se acaben los mensajes, desactivar el objeto
            objetoParaDesactivar.SetActive(false);

            // Opcional: ocultar el texto del tutorial
            textoTutorial.gameObject.SetActive(false);

            // Cargar la escena final
            SceneManager.LoadScene(escenaAFinalizar);
        }
    }
}
