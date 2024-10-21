using UnityEngine;

public class MovimientoTopDown : MonoBehaviour
{
    public Animator miAnimador;
    public float velocidadMovimiento;
    public bool caminando;

    public float multiplicadorVelocidad;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            multiplicadorVelocidad = 1;            
        }else{
            multiplicadorVelocidad = 0.5f;            
        }

        Vector2 entradaUsuario = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        transform.position = new Vector3(transform.position.x + (entradaUsuario.x * Time.deltaTime * velocidadMovimiento * multiplicadorVelocidad),
                                transform.position.y + (entradaUsuario.y * Time.deltaTime * velocidadMovimiento * multiplicadorVelocidad),
                                0);

        if (entradaUsuario == Vector2.zero)
        {
            caminando = false;
        }
        else
        {
            caminando = true;
        }
        //Actualizar el animador
        miAnimador.SetBool("caminando", caminando);


        miAnimador.SetFloat("dirY", entradaUsuario.y * multiplicadorVelocidad);
        miAnimador.SetFloat("dirX", entradaUsuario.x * multiplicadorVelocidad);

    }
}
