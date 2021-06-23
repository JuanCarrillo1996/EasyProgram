using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
public class ExitCredits : MonoBehaviour
{

    public int sceneloader;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) )
        {
            SceneManager.LoadScene(sceneloader);
        }
        
    }
}
