using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaludPersonaje : MonoBehaviour
{
    public int saludActual = 5;
    Rigidbody2D miCuerpo;
    public float empujeDano = 2;
    private int cantidadVidas = 3;
    
    public SpriteRenderer miRenderer;
    public Collider2D miCollider;
    public GameObject gorraPersonaje;

    public bool muerto = false;

    void Start(){
        miCuerpo = GetComponent<Rigidbody2D>();
        ControlIU.Instance.ActualizarIUVidas(cantidadVidas);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (muerto == true)
        {
            return;
        }
        if (other.transform.CompareTag("bala"))
        {
            saludActual--;
            Destroy(other.gameObject);

            if (ObtenerSaludActual() <= 0)
            {
                MatarPersonaje();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (muerto == true)
        {
            return;
        }

        if (other.transform.CompareTag("enemigo"))
        {
            saludActual -= 2;

            miCuerpo.AddForce(new Vector2(empujeDano * -1, empujeDano), ForceMode2D.Impulse);

            if (ObtenerSaludActual() <= 0)
            {
                MatarPersonaje();
            }
        }  
    }

    int ObtenerSaludActual()
    {
        return saludActual;
    }

    void MatarPersonaje(){
        muerto = true;
        transform.localEulerAngles = new Vector3(0, 0, 90);
        //miRenderer.enabled = false;
        //miCollider.enabled = false;
        //miCuerpo.simulated = false;
        //gorraPersonaje.SetActive(false);
        StartCoroutine(ReiniciarNivel());
    }

    IEnumerator ReiniciarNivel(){
        yield return new WaitForSeconds(5f);

        if (cantidadVidas > 0)
        {
            cantidadVidas--;
            ReiniciarJuego();
        }
        else
        {
            if (ControlJuego.Instance.cantidadCreditos > 0)
            {
                cantidadVidas = 3;
                ControlJuego.Instance.ReducirCreditos();
                ReiniciarJuego();
            }
            else
            {
                ControlIU.Instance.MostrarMenuGameOver();
            }
        }
        //SceneManager.LoadScene("470");
    }

    public void ReiniciarJuego()
    {
        transform.position = new Vector3(transform.position.x,
                                           transform.position.y + 10,
                                           transform.position.z);

        transform.localEulerAngles = new Vector3(0, 0, 0);
        muerto = false;
        saludActual = 1;
        ControlIU.Instance.ActualizarIUVidas(cantidadVidas);
    }
}
