using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlArmas : MonoBehaviour
{
    public MovimientoTransform movTransform;
    public GameObject proyectil;
    public Transform transformArma;

    void Update()
    {
        if (movTransform.miCuerpo.velocity.y == 0 && Input.GetButtonDown("Fire1"))
        {
            Atacar();
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
