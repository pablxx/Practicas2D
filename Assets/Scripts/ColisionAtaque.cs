using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionAtaque : MonoBehaviour
{
    //public Animator animadorEventos;
    public BoxCollider2D colision;

    void Start()
    {
        //animadorEventos = GetComponent<Animator>();
        colision = GetComponent<BoxCollider2D>();
    }

    public void ActivarColisiones()
    {
        colision.enabled = true;
    }

    public void DesactivarColisiones()
    {
        colision.enabled = false;
    }

}
