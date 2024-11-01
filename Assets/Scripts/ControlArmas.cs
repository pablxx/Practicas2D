using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlArmas : MonoBehaviour
{
    public MovimientoTransform movTransform;
    public Transform transformArma;
    public Arma armaMano;
    public Arma armaArrojadiza;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            armaMano.Disparar();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            armaArrojadiza.Disparar();
        }
    }

    
}
