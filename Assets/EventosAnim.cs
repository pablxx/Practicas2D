using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventosAnim : MonoBehaviour
{
    public PersonajeEsqueletos personaje;

    public void EjecutarEventoRecoger()
    {
        personaje.RecogerObjeto();
    }
}
