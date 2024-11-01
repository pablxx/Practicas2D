using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilExplosivo : MonoBehaviour
{
    public float tiempoEspera = 3;
    public float areaGranada;
    public LayerMask capaEnemigos;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExplotarGranada());
    }

    IEnumerator ExplotarGranada()
    {
        yield return new WaitForSeconds(tiempoEspera);
        RaycastHit2D enemigosDetectados = Physics2D.CircleCast(transform.position, 
                                                                areaGranada, 
                                                                Vector2.right,
                                                                capaEnemigos);
        if (enemigosDetectados == true)
        {
            Debug.Log("Enemigos detectados");
        }
        else
        {
            Debug.Log("No habia nada :(");
        }
        Destroy(gameObject);
    }
}
