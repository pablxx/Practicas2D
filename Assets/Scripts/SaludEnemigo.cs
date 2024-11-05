using UnityEngine;

public class SaludEnemigo : MonoBehaviour
{
    public float saludEnemigo = 5;

    public void AplicarDaño(float dañoObjetivo)
    {
        if (saludEnemigo - dañoObjetivo > 0)
        {
            saludEnemigo -= dañoObjetivo;
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
        //saludEnemigo -= otroObjeto.GetComponent<MoverBala>().dañoBala;
       // otroObjeto.GetComponent<MoverBala>().dañoBala;
    }

    float ObtenerSaludActual()
    {
        return saludEnemigo;
    }
}
