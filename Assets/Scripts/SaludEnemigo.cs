using UnityEngine;

public class SaludEnemigo : MonoBehaviour
{
    public float saludEnemigo = 5;

    public void AplicarDa�o(float da�oObjetivo)
    {
        if (saludEnemigo - da�oObjetivo > 0)
        {
            saludEnemigo -= da�oObjetivo;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D otroObjeto)
    {
        if (otroObjeto.transform.CompareTag("bala"))
        {
            saludEnemigo--;
            Destroy(otroObjeto.gameObject);

            if (ObtenerSaludActual() <= 0)
            {
                Destroy(gameObject);
            }
            //saludEnemigo =- 1;
            //saludEnemigo = saludEnemigo - 1;
        }
        //Debug.Log("Choque con : " + otroObjeto.name);
        //saludEnemigo -= otroObjeto.GetComponent<MoverBala>().da�oBala;
       // otroObjeto.GetComponent<MoverBala>().da�oBala;
    }

    float ObtenerSaludActual()
    {
        return saludEnemigo;
    }
}
