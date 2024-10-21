using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJuego : MonoBehaviour
{
    public int cantidadTiempo = 60;

    void Start()
    {
        ControlIU.Instance.ActualizarIUReloj(cantidadTiempo);
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
}
