//LIBRERIAS IMPORTADAS
using UnityEngine;

//CLASE
//[RequireComponent("Rigidbody2D")]
public class MovimientoTransform : MonoBehaviour
{
    //VARIABLES y constantes
    public Transform miTransform;
    public float miVelocidad;

    public Vector2 fuerzaSalto;
    public Rigidbody2D miCuerpo;

    //METODOS
    void Start()
    {
        //Debug.Log("Estoy en el metodo Start");
    }

    void Update()
    {
        //Debug.Log("Estoy en el metodo Update");
        Movimiento();

    }

    void Movimiento()
    {
        float inputX = Input.GetAxis("Horizontal");

        if (inputX != 0)
        {
            miTransform.position = new Vector3(miTransform.position.x + (miVelocidad * inputX * Time.deltaTime),
                                                miTransform.position.y,
                                                miTransform.position.z);

            if (inputX > 0 && miTransform.localScale.x < 0)
            {
                miTransform.localScale = new Vector3(miTransform.localScale.x * -1,
                                                    miTransform.localScale.y, miTransform.localScale.z);
            }
            else if (inputX < 0 && miTransform.localScale.x > 0)
            {
                miTransform.localScale = new Vector3(miTransform.localScale.x * -1,
                                                    miTransform.localScale.y, miTransform.localScale.z);
            }
        }

        if (Input.GetButtonDown("Jump"))
        {
            miCuerpo.AddForce(fuerzaSalto, ForceMode2D.Impulse);
        }
    }

    //#region funciones
    void FixedUpdate()
    {
        //Debug.Log("Estoy en el metodo FixedUpdate");
    }

    void Awake()
    {
        //Debug.Log("Estoy en el metodo Awake");
    }
    //#endregion
}


//CONTROL DE UNA DIRECCION A LA VEZ
// if (Input.GetKey(KeyCode.D))
// {
//     miTransform.position = new Vector3(miTransform.position.x + 0.025f,
//                                        miTransform.position.y,
//                                        miTransform.position.z);
// }

// if (Input.GetKey(KeyCode.A))
// {
//     miTransform.position = new Vector3(miTransform.position.x - 0.025f,
//                                        miTransform.position.y,
//                                        miTransform.position.z);
// }

// if (Input.GetKey(KeyCode.W))
// {
//     miTransform.position = new Vector3(miTransform.position.x,
//                                        miTransform.position.y + 0.025f,
//                                        miTransform.position.z);
// }

// if (Input.GetKey(KeyCode.S))
// {
//     miTransform.position = new Vector3(miTransform.position.x,
//                                        miTransform.position.y - 0.025f,
//                                        miTransform.position.z);
// }

//CODIGO PARA UN POSIBLE SALTO DIRECCIONAL
// if (Input.GetKeyDown(KeyCode.D))
// {
//     miTransform.position = new Vector3(miTransform.position.x + 0.5f,
//                                        miTransform.position.y,
//                                        miTransform.position.z);
// }

// if (Input.GetKeyDown(KeyCode.A))
// {
//     miTransform.position = new Vector3(miTransform.position.x - 0.5f,
//                                        miTransform.position.y,
//                                        miTransform.position.z);
// }

// if (Input.GetKeyDown(KeyCode.W))
// {
//     miTransform.position = new Vector3(miTransform.position.x,
//                                        miTransform.position.y + 0.5f,
//                                        miTransform.position.z);
// }

// if (Input.GetKeyDown(KeyCode.S))
// {
//     miTransform.position = new Vector3(miTransform.position.x,
//                                        miTransform.position.y - 0.5f,
//                                        miTransform.position.z);
// }
