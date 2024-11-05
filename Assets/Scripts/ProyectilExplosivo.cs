using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilExplosivo : MonoBehaviour
{
    public float tiempoEspera = 3;
    private float dañoProyectil;
    private float areaGranada;
    public LayerMask capaEnemigos;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExplotarGranada());
    }

    public void ActualizarDatos(float areaEfecto, float daño)
    {
        areaGranada = areaEfecto;
        dañoProyectil = daño;
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
            for (int i = 0; i < enemigosDetectados.Length; i++)
            {
                enemigosDetectados[i].transform.GetComponent<SaludEnemigo>().AplicarDaño(dañoProyectil);
            }
        }
        else
        {
            Debug.Log("No habia nada :(");
        }
        Destroy(gameObject);
    }
}
