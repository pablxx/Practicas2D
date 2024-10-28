using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeEsqueletos : MonoBehaviour
{
    public Animator miAnimador;
    public Rigidbody2D miCuerpo;
    public float velMax;
    public float multipVel;
    public float valorMultiplicador;
    //public bool corriendo;

    void Update()
    {
        Vector2 entradaJugador = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if ((entradaJugador.x > 0 && transform.localScale.x < 0) ||
            entradaJugador.x < 0 && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
        }
        

        if (Input.GetKey(KeyCode.LeftShift))
        {
            multipVel = 1;
        }
        else
        {
            multipVel = valorMultiplicador;
        }

        miCuerpo.velocity = new Vector2(entradaJugador.x * velMax * multipVel, miCuerpo.velocity.y);
        miAnimador.SetFloat("velX", Mathf.Abs(miCuerpo.velocity.x));
    }
}
