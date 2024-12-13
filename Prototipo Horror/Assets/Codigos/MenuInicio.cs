using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour
{
    public string nombreEscena; // Nombre de la escena a la que quieres cambiar

    // M�todo para iniciar el juego
    public void IniciarJuego()
    {
        SceneManager.LoadScene(nombreEscena); // Cambia a la escena especificada
    }

    // M�todo para salir del juego
    public void SalirDelJuego()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Solo para el modo de edici�n en Unity Editor
#else
            Application.Quit(); // Cierra la aplicaci�n en modo de ejecuci�n
#endif
    }
}
