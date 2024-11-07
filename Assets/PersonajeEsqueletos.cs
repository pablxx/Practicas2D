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
    public bool objetoCerca;
    public Transform huesoMano;
    public Transform objetoEnMano;
    public Vector2 fuerzaLanzamiento;
    //public AudioClip[] misPasos;
    public AudioSource miParlante;
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

        if (Input.GetButtonDown("Fire2") && objetoEnMano == true)
        {
            miAnimador.SetTrigger("ataqueL");
        }

        if (Input.GetKeyDown(KeyCode.F) && objetoCerca == true)
        {
            miAnimador.SetTrigger("recoger");

            //miAnimador.SetLayerWeight(1, 1);
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
    }

    public void RecogerObjeto() {
        if (objetoEnMano != null)
        {
            Debug.Log("Intentando recoger");
            objetoEnMano.GetComponent<Rigidbody2D>().simulated = false;
            objetoEnMano.GetComponent<Collider2D>().enabled = false;
            objetoEnMano.parent = huesoMano;
            objetoEnMano.position = new Vector2(huesoMano.position.x + 1f, huesoMano.position.y);
            StartCoroutine(RutinaSubirBrazos());
        }
    }

    public void SonidoPasos(){
        miParlante.Play();
    }

    public void ArrojarObjeto()
    {
        if (objetoEnMano != null)
        {
            Debug.Log("Soltando recoger");
            Rigidbody2D cuerpoObjeto = objetoEnMano.GetComponent<Rigidbody2D>();
            cuerpoObjeto.simulated = true;

            objetoEnMano.GetComponent<Collider2D>().enabled = true;
            objetoEnMano.parent = null;

            cuerpoObjeto.AddForce(new Vector2(transform.localScale.x * fuerzaLanzamiento.x, fuerzaLanzamiento.y),
                                  ForceMode2D.Impulse);

            cuerpoObjeto.AddTorque(-4f, ForceMode2D.Impulse);
            
            StartCoroutine(RutinaBajarBrazos());
        }
        
    }

    IEnumerator RutinaSubirBrazos()
    {
        while (miAnimador.GetLayerWeight(1) < 1)
        {
            float pesoActual = miAnimador.GetLayerWeight(1);
            miAnimador.SetLayerWeight(1, pesoActual + 0.25f);
            yield return null;
        }
    }

    IEnumerator RutinaBajarBrazos()
    {
        while (miAnimador.GetLayerWeight(1) > 0)
        {
            float pesoActual = miAnimador.GetLayerWeight(1);
            miAnimador.SetLayerWeight(1, pesoActual - 0.25f);
            yield return null;
        }
        objetoEnMano = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("recogible"))
        {
            objetoCerca = true;
            objetoEnMano = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("recogible"))
        {
            objetoCerca = false;
            //objetoEnMano = null;
        }
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
