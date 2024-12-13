using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemigo : MonoBehaviour
{
    public GameObject[] efectosObjetos;
    static public int indiceDeefectosActivos;

    public float[] limTemp;
    float temp;

    void Start()
    {
        indiceDeefectosActivos = 0;
        Llave.desactivar += DesactivarEfectoEnemigo;

        foreach (GameObject obj in efectosObjetos)
            obj.SetActive(false);
    }

    void Update()
    {
        TemporizadoEfectos();
    }

    void TemporizadoEfectos()
    {
        if (indiceDeefectosActivos < limTemp.Length)
        {
            if (temp < limTemp[indiceDeefectosActivos])
                temp += Time.deltaTime;
            else
            {
                temp = 0;
                efectosObjetos[indiceDeefectosActivos].SetActive(true);
                indiceDeefectosActivos++;
            }
        }
    }

    public void DesactivarEfectoEnemigo(int indice)
    {
        if (indiceDeefectosActivos > 0)
        {
            efectosObjetos[indiceDeefectosActivos - 1].SetActive(false);
            temp = 0;
            indiceDeefectosActivos--;
        }
        else
        {
            temp = 0;
        }
    }
}
