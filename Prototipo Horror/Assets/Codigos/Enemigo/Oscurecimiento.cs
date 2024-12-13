using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscurecimiento : MonoBehaviour
{
    public GameObject oscuridad;

    private void OnEnable()
    {
        oscuridad.SetActive(true);
    }

    private void OnDisable()
    {
        oscuridad.SetActive(false);
    }
}
