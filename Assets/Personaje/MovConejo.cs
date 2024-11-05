using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovConejo : MonoBehaviour
{
    public float movX;
    public float movY;
    public float fuerzaSalto;
    public bool corriendo;
    public Animator miAnimator;
    public Rigidbody2D miBody2D;
    

    public bool golpeando;
    public int nrogolpes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //correr
        Vector2 entradaUsuario = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        transform.position = new Vector3(transform.position.x + (entradaUsuario.x * Time.deltaTime),
                                        transform.position.y, 0);

        if (Input.GetButton("Horizontal"))
        {
            corriendo = true;
        }
        else
        {
            corriendo = false;
        }

        //golpes
        if(Input.GetKeyDown(KeyCode.K))
        {
            golpeando = true;
            nrogolpes = 1;
            miAnimator.SetFloat("Golpeando", nrogolpes);
            if (Input.GetKey(KeyCode.K) && nrogolpes == 1) 
            {
                golpeando = true;
                miAnimator.SetFloat("Golpeando", nrogolpes);
                nrogolpes = 2;
                if (Input.GetKey(KeyCode.K) && nrogolpes == 2)
                {
                    golpeando = true;
                    nrogolpes = 3;
                    miAnimator.SetFloat("Golpeando", nrogolpes);

                }
                nrogolpes = 0;
            }
            nrogolpes = 0;
        }
        else
        {
            nrogolpes = 0;
        }

        
        
            


            miAnimator.SetFloat("MovX", movX);
    }

    
}
