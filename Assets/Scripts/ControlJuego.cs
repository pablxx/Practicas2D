using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJuego : MonoBehaviour
{
    public static ControlJuego Instance;

    public int cantidadTiempo = 60;
    public int cantidadCreditos = 2;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        ControlIU.Instance.ActualizarIUReloj(cantidadTiempo);
        ControlIU.Instance.ActualizarIUCreditos(cantidadCreditos);
        StartCoroutine(TemporizadorJuego());
    }

    IEnumerator TemporizadorJuego()
    {
        while (cantidadTiempo > 0)
        {
            yield return new WaitForSeconds(4f);
            cantidadTiempo--;
            ControlIU.Instance.ActualizarIUReloj(cantidadTiempo);
        }

        //Debug.Log("El tiempo se acabo!!");
        ControlIU.Instance.MostrarMenuGameOver();
    }

    public void ReducirCreditos()
    {
        cantidadCreditos--;
        ControlIU.Instance.ActualizarIUCreditos(cantidadCreditos);
    }
}
