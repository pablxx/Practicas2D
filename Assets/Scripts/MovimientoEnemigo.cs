using System.Collections;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    public int tiempoEsperaEnemigo = 5;
    public Transform puntoA, puntoB;
    public Transform puntoActual, puntoSiguiente;   
    public bool cambiarDeLado; 
    public float velocidadEnemigo = 4f;

    void Start()
    {
        StartCoroutine(EsperaMover());
    }

    IEnumerator EsperaMover(){
        yield return new WaitForSeconds(tiempoEsperaEnemigo);
        cambiarDeLado = true;
    }

    void Update()
    {
        if (cambiarDeLado == true)
        {
            if (Vector3.Distance(transform.position, puntoSiguiente.position) > 0.05f)
            {
                transform.position = Vector3.MoveTowards(transform.position, 
                                                    puntoSiguiente.position, 
                                                    velocidadEnemigo * Time.deltaTime);
            }else{
                cambiarDeLado = false;

                transform.localScale = new Vector3(transform.localScale.x * -1f,
                                                   transform.localScale.y,
                                                   transform.localScale.z);

                puntoActual = puntoSiguiente;

                if (puntoActual == puntoA)
                {
                    puntoSiguiente = puntoB;
                }else{
                    puntoSiguiente = puntoA;
                }
                StartCoroutine(EsperaMover());
            }
        }
    }
}
