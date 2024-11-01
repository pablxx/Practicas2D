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
    public bool enPiso;
    public Transform detectorPies;
    public LayerMask capaPiso;
    public float fuerzaSalto;
    //public bool corriendo;

    void Update()
    {
        Vector2 entradaJugador = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        miAnimador.SetFloat("velX", Mathf.Abs(miCuerpo.velocity.x));
        miAnimador.SetFloat("velY", miCuerpo.velocity.y);
        miAnimador.SetBool("enPiso", enPiso);

        if ((entradaJugador.x > 0 && transform.localScale.x < 0) ||
            entradaJugador.x < 0 && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            miAnimador.SetBool("muerto", true);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            miAnimador.SetTrigger("daño");
        }

        if (Input.GetButtonDown("Fire1"))
        {
            miAnimador.SetTrigger("ataqueC");
        }
        if (Input.GetButtonDown("Fire2"))
        {
            miAnimador.SetTrigger("ataqueL");
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            miAnimador.SetLayerWeight(1, 1);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            multipVel = 1;
        }
        else
        {
            multipVel = valorMultiplicador;
        }

        if (Input.GetButtonDown("Jump"))
        {
            miCuerpo.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse);
        }

        miCuerpo.velocity = new Vector2(entradaJugador.x * velMax * multipVel, miCuerpo.velocity.y);
        
        
    }

    private void FixedUpdate()
    {
        DetectarPiso();
    }

    void DetectarPiso()
    {
        RaycastHit2D choquePiso = Physics2D.Raycast(detectorPies.position, Vector2.down, 0.15f, capaPiso);

        if (choquePiso == true)
        {
            enPiso = true;
        }
        else
        {
            enPiso = false;
        }
    }
}
