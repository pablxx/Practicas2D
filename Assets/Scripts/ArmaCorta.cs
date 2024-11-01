using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaCorta : Arma
{
    public ControlArmas controlArmas;
    public override void Disparar()
    {
        GameObject bala = Instantiate(proyectil,
                                    controlArmas.transformArma.position,
                                    controlArmas.transformArma.rotation);

        bala.GetComponent<MoverBala>().ActualizarDireccion(transform.localScale.x);
        //la linea base, ejecuta primero lo del padre
        //base.Disparar();
    }
}
