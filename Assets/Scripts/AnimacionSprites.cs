using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionSprites : MonoBehaviour
{
    public Animator miAnimador;
    public float velocidad;
    public bool atacando;
    
    //public Transform miTranforma;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float entradaX = Input.GetAxis("Horizontal");

        if (entradaX != 0 && atacando == false)
        {
            miAnimador.SetBool("correr", true);
            transform.position = new Vector3(transform.position.x + velocidad * entradaX, 
                                             transform.position.y, 
                                             transform.position.z);

            if (transform.localScale.x > 0 && entradaX < 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1,
                                                    transform.localScale.y, transform.localScale.z);
            }
            else if(transform.localScale.x < 0 && entradaX > 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1,
                                                    transform.localScale.y, transform.localScale.z);
            }
        }else if(entradaX == 0){
            miAnimador.SetBool("correr", false);
        }

        if (Input.GetButtonDown("Fire1") && atacando == false && entradaX == 0)
        {
            atacando = true;
            miAnimador.SetTrigger("atacar");
            StartCoroutine(CancelarAtaque());
        }
    }

    //CORUTINA
    IEnumerator CancelarAtaque()
    {
        yield return new WaitForSeconds(.75f);
        atacando = false;
    }
}
