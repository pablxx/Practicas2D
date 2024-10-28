
using UnityEngine;

public abstract class Arma : MonoBehaviour
{
    public string nombre;
    public int cantidadBalas;
    public float daño;
    public float rango;
    public float cadencia;
    public Sprite icono;
    public Sprite grafico;
    public GameObject proyectil;
    public TipoArma tipoArma;

    public virtual void Disparar()
    {
        //Debug.Log("Inicia la clase padre");
    }
}

public enum TipoArma
{
    Corta, Larga, Arrojadiza, Explosiva
}