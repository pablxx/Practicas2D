using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeEsqueletos : MonoBehaviour
{
    public Animator miAnimador;
    public Rigidbody2D miCuerpo;
    void Start()
    {
        
    }

    void Update()
    {
        Vector2 entradaJugador = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
        miCuerpo.velocity = new Vector2(entradaJugador.x * 2, miCuerpo.velocity.y);
        miAnimador.SetFloat("velX", miCuerpo.velocity.x);
    }
}
