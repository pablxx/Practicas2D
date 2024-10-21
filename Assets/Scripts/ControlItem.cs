using UnityEngine;

public class ControlItem : MonoBehaviour
{
    [SerializeField] private int puntajeItem;

    private void OnTriggerEnter2D(Collider2D otroObjeto)
    {
        if (otroObjeto.CompareTag("Player"))
        {
            ControlPuntaje.Instance.IncrementarPuntaje(puntajeItem);
            Destroy(gameObject);
        }
    }
}
