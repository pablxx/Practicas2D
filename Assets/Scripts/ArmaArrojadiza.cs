using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaArrojadiza : Arma
{
    public ControlArmas controlArmas;
    public float areaEfecto;

    //public float fuerzaLanzamiento;

    private void Start()
    {
        ControlIU.Instance.ActualizarIUGranadas(cantidadBalas);
    }

    public override void Disparar()
    {
        if (cantidadBalas > 0)
        {
            cantidadBalas--;

            ControlIU.Instance.ActualizarIUGranadas(cantidadBalas);

            GameObject nuevaBala = Instantiate(proyectil,
                                   controlArmas.transformArma.position,
                                   controlArmas.transformArma.rotation);

            //nuevaBala.GetComponent<CircleCollider2D>().radius = areaEfecto;
            ProyectilExplosivo proyectilExplosivo = nuevaBala.GetComponent<ProyectilExplosivo>();
            //pE.areaGranada = areaEfecto;
            //pE.dañoProyectil = daño;
            proyectilExplosivo.ActualizarDatos(areaEfecto, daño);



            nuevaBala.GetComponent<Rigidbody2D>()
                        .AddForce(new Vector2(transform.localScale.x * rango,
                                              rango / 2), ForceMode2D.Impulse);
        }
        else
        {
            Debug.Log("No tengo mas granadas");
        }
        //la linea base, ejecuta primero lo del padre
        //base.Disparar();
    }
    
}
