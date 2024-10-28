using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlArmas : MonoBehaviour
{
    public MovimientoTransform movTransform;
    public GameObject proyectil;
    public Transform transformArma;
    public Arma armaMano;
    public Arma armaArrojadiza;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Atacar();
            armaMano.Disparar();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            armaArrojadiza.Disparar();
        }
    }

    void Atacar()
    {
        Debug.Log("ATACO!!!!");
        GameObject bala = Instantiate(proyectil,
                                    transformArma.position, 
                                    transformArma.rotation);
        bala.GetComponent<MoverBala>().ActualizarDireccion(transform.localScale.x);
        //bala.SendMessage("MoverBala");
        //AQUI DEBERIAMOS ATACAR
    }
}
