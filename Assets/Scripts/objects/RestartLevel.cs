using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    public int sceneloader;
    private int levelToLoad;
    public Animator animator;

    private void OnTriggerStay(Collider cubo)
    {
        FadeToLevel(sceneloader);
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
