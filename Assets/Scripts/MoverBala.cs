using UnityEngine;

public class MoverBala : MonoBehaviour
{
    public float velocidadBala;
    public float direccionBala;
    //public int da�oBala = 10;
    void Update()
    {
        transform.position =
            new Vector3(transform.position.x + velocidadBala * Time.deltaTime * direccionBala, 
            transform.position.y,
            transform.position.z);
        
    }

    public void ActualizarDireccion(float direccionPadre)
    {
        direccionBala = Mathf.Sign(direccionPadre);
    }
}
