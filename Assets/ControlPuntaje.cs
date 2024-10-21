using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPuntaje : MonoBehaviour
{
    public static ControlPuntaje Instance;
    
    [SerializeField] private int puntajeActual;

    void Start()
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

    public void IncrementarPuntaje(int incremento)
    {
        puntajeActual += incremento;
        //puntajeActual = puntajeActual + incremento;
        ControlIU.Instance.ActualizarIUPuntaje(puntajeActual);
    }
}
