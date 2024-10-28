using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaArrojadiza : Arma
{
    public override void Disparar()
    {
        Instantiate(proyectil, transform.position, transform.rotation);
        //la linea base, ejecuta primero lo del padre
        //base.Disparar();
    }
    
}
