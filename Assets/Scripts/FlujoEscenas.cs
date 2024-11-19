using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlujoEscenas : MonoBehaviour
{
    public string escenaObjetivo;
    //public Button miBoton;

    //private void Start()
    //{
    //    miBoton.onClick.AddListener(IrAEscenaQuemada);
    //}

    public void IrAEscenaQuemada()
    {
        SceneManager.LoadScene("470");
    }

    public void IrAEscenaVariable()
    {
        SceneManager.LoadScene(escenaObjetivo);
    }

    public void IrAEscenaConParametro(string escenaNueva)
    {
        SceneManager.LoadScene(escenaNueva);
    }
}
