using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//Libreria para usar el apartado Text;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    //instanciar la clase controllesr para poderse usarse en otros scripts
    public static Controller myinstant;


    //Definicion de los campos para poderse ver en Unity.
    public GameObject dialogo;
    public Text txtDialogo;
    //Etiquetas para que salgan en la interfaz de Unity.
    [Header("Configuracion de teclado")]
    //Configuracion de teclas
    public KeyCode teclaSiguientedialogo;
    public KeyCode teclaEjecucionDia = KeyCode.E;
    //public KeyCode teclaEjecucionDia = KeyCode.E;
    [Header("Ensayo")]
    public Frase[] dialogoPersona;

     private void Awake()
     {
         if (myinstant == null)
         {
             //auto iniciacion
             myinstant = this;
         }
         else
         {
            DestroyImmediate(gameObject);
         }
     }

    void Start()
    {
        dialogo.SetActive(false);
    }

    public IEnumerator Comenta(Frase[] _dialogo)
    {
        dialogo.SetActive(true);
        for (int i = 0; i < _dialogo.Length; i++)
        {
            txtDialogo.text = _dialogo[i].texto;
            yield return new WaitForSeconds(0.5f);
            yield return new WaitUntil(() => Input.GetKeyUp(teclaSiguientedialogo));
        }
        dialogo.SetActive(false);
    }
    [ContextMenu("Activar prueba")]
    public void Prueba()
    {
        StartCoroutine(Comenta(dialogoPersona));
    }
}
[System.Serializable]
public class Frase
{
    public string texto;

}

[System.Serializable]
public class EstadoDialogo
{
    public Frase[] frases;
}