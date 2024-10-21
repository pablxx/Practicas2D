using UnityEngine;
public class MoverAnimadoFisica : MonoBehaviour
{
    public float velocidad;
    public float fuerzaSalto;
    public Rigidbody2D miCuerpo;
    public Animator miAnimador;
    public Transform piesPersonaje;
    public bool pisando;

    public LayerMask capaPiso;

    public bool muerto = false;

    void Start()
    {
        miCuerpo = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            muerto = true;
            miAnimador.SetBool("muerto", muerto);
        }

        if (muerto == true)
        {
            return;
        }

        float entradaX = Input.GetAxis("Horizontal");
        
        miAnimador.SetFloat("velY", miCuerpo.velocity.y);

        if (entradaX != 0)
        {
            miCuerpo.velocity = new Vector2(velocidad * entradaX, miCuerpo.velocity.y);
            miAnimador.SetFloat("velX", Mathf.Abs(miCuerpo.velocity.x));

            if ((transform.localScale.x < 0 && entradaX > 0) || (transform.localScale.x > 0 && entradaX < 0))
            {
                transform.localScale = new Vector3(transform.localScale.x * -1f,
                                                   transform.localScale.y,
                                                   transform.localScale.z);
            }
        } else if (entradaX == 0) {
            miCuerpo.velocity = new Vector2(0, miCuerpo.velocity.y);
            miAnimador.SetFloat("velX", miCuerpo.velocity.x);
        }

        if (Input.GetButtonDown("Jump") && pisando == true)
        {
            miCuerpo.AddForce(new Vector2(0f, fuerzaSalto), ForceMode2D.Impulse);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            miAnimador.SetTrigger("disparo");
        }

        if (Input.GetButtonDown("Fire3"))
        {
            miAnimador.SetTrigger("golpe");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            miAnimador.SetTrigger("deslizar");
        }

        //miCuerpo.AddForce(new Vector2(velocidad, 0f), ForceMode2D.Force);
    }

    private void FixedUpdate()
    {
        RaycastHit2D miRayo = Physics2D.Raycast(piesPersonaje.position, Vector2.down, 0.5f, capaPiso);

        if (miRayo.collider != null)
        {
            pisando = true;
            miAnimador.SetBool("pisando", pisando);
        }
        else
        {
            pisando = false;
            miAnimador.SetBool("pisando", pisando);
        }
    }

    //
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(piesPersonaje.position, Vector2.down);
    }
}
