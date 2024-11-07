using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilExplosivo : MonoBehaviour
{
    public float tiempoEspera = 3;
    private float da�oProyectil;
    private float areaGranada;
    public LayerMask capaEnemigos;
    
    void Start()
    {
        StartCoroutine(ExplotarGranada());
    }

    public void ActualizarDatos(float areaEfecto, float da�o)
    {
        areaGranada = areaEfecto;
        da�oProyectil = da�o;
    }

    IEnumerator ExplotarGranada()
    {
        yield return new WaitForSeconds(tiempoEspera);
        RaycastHit2D[] enemigosDetectados = Physics2D.CircleCastAll(transform.position, 
                                                                areaGranada, 
                                                                Vector2.right,
                                                                capaEnemigos);
        
        if (enemigosDetectados.Length > 0)
        {
            Debug.Log("Enemigos detectados");
            for (int i = 0; i < enemigosDetectados.Length - 1; i++)
            {
                SaludEnemigo saludEnemigo = enemigosDetectados[i].transform.GetComponent<SaludEnemigo>();
                if (saludEnemigo != null)
                {
                    saludEnemigo.AplicarDa�o(da�oProyectil);
                }
            }
        }
        else
        {
            Debug.Log("No habia nada :(");
        }
        Destroy(gameObject);
    }
}
