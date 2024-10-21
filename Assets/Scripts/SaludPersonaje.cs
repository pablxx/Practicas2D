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

    void Start(){
        miCuerpo = GetComponent<Rigidbody2D>();
        ControlIU.Instance.ActualizarIUVidas(cantidadVidas);
    }

    private void OnTriggerEnter2D(Collider2D other) {
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
        miRenderer.enabled = false;
        miCollider.enabled = false;
        miCuerpo.simulated = false;
        gorraPersonaje.SetActive(false);
        StartCoroutine(ReiniciarNivel());
    }

    IEnumerator ReiniciarNivel(){
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("470");
    }
}
