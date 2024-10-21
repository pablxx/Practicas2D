using UnityEngine;

public class SaludEnemigo : MonoBehaviour
{
    public int saludEnemigo = 5;

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

    int ObtenerSaludActual()
    {
        return saludEnemigo;
    }
}
