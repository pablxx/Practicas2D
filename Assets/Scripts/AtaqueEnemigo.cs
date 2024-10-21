using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEnemigo : MonoBehaviour
{
    public float esperaDisparo = 2f;
    public GameObject bala;
    public Transform manoEnemigo;

    void Start()
    {
        StartCoroutine(EsperaParaDisparar());
    }

   IEnumerator EsperaParaDisparar(){
    yield return new WaitForSeconds(esperaDisparo);
    GameObject nuevaBala = Instantiate(bala, manoEnemigo.position, manoEnemigo.rotation);
    nuevaBala.GetComponent<MoverBala>().ActualizarDireccion(transform.localScale.x);
    StartCoroutine(EsperaParaDisparar());
   }
}
