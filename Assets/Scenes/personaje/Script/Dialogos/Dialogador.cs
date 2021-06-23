using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Dialogador : MonoBehaviour
{
    public EstadoDialogo[] estados;
    public int estadoActual = 0;
    public Animator animator;
    private int levelToLoad;
    public int requireSceneChange;
    public int sceneloader;

    //Esta funcion se hace para cuando el player colision con el objeto
    //se active el dialogo.
    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(Controller.myinstant.teclaEjecucionDia))
            {
                StartCoroutine(Controller.myinstant.Comenta(estados[estadoActual].frases));
            }

            if (Controller.myinstant.dialogo.active == false && requireSceneChange == 1)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    FadeToLevel(sceneloader);
                }
            }

        }
    }

    public void FadeToLevel(int levelIndex)
    {

        Debug.Log("FadeToLevel antes de cambiar");
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
        SceneManager.LoadScene(levelToLoad);
        Debug.Log("FadeToLevel despues de cambiar");
    }

    public void OnFadeComplete()
    {
        Debug.Log("OnFadeComplete antes de cambiar");
        SceneManager.LoadScene(levelToLoad);
        Debug.Log("OnFadeComplete despues de cambiar");
    }
}