using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manchas : MonoBehaviour
{
    public GameObject objeto;
    public ParticleSystem particulas;

    private void OnEnable()
    {
        objeto.SetActive(true);
        particulas.Play();
    }

    private void OnDisable()
    {
        objeto.SetActive(false);
        particulas.Stop();
    }
}
