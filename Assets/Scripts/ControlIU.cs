using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControlIU : MonoBehaviour
{
    public static ControlIU Instance;
    public TMP_Text textoReloj;
    public TMP_Text textoPuntaje;
    public TMP_Text textoVidas;

    public GameObject menuGameOver;
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

    public void ActualizarIUReloj(int tiempoRestante)
    {
        textoReloj.text = tiempoRestante.ToString();
    }

    public void MostrarMenuGameOver()
    {
        menuGameOver.SetActive(true);
    }

    public void ActualizarIUPuntaje(int puntajeActual)
    {
        textoPuntaje.text = puntajeActual.ToString();
    }

    public void ActualizarIUVidas(int cantidadVidas)
    {
        textoVidas.text = cantidadVidas.ToString();
    }
}
