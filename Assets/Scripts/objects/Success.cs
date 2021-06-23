using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Success : MonoBehaviour
{
    public GameObject SuccessFloat;
    public GameObject SuccessInt;
    public GameObject SuccessBool;
    public GameObject SuccessChar;
    public GameObject SuccessLevel;

    void Update()
    {   

        //if (SuccessFloat.gameObject.activeSelf && !SuccessInt.gameObject.activeSelf && !SuccessBool.gameObject.activeSelf && !SuccessChar.gameObject.activeSelf) 

        if(SuccessChar.gameObject.activeSelf == true && SuccessFloat.gameObject.activeSelf == true && SuccessInt.gameObject.activeSelf == true
            && SuccessBool.gameObject.activeSelf == true)
        {
            SuccessLevel.gameObject.SetActive(true);
        }
        else
        {
            SuccessLevel.gameObject.SetActive(false);
        }

    }
}
