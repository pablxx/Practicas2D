using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ControlItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otroObjeto)
    {
        if (otroObjeto.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
