using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirPorTiempo : MonoBehaviour
{
    float tiempoDestruccion = 2f;

    // Update is called once per frame
    void Update()
    {
        if (tiempoDestruccion > 0)
        {
            tiempoDestruccion -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
