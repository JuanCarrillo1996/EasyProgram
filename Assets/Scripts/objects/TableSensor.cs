using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableSensor : MonoBehaviour
{

    public GameObject succesfulBanner;
    private int Cont1 = 0;
    private int Cont2 = 0;
    private int Cont3 = 0;
    public string Cubo1;
    public string Cubo2;
    public string Cubo3;

    void Start()
    {
        succesfulBanner.gameObject.SetActive(false);
    }

    private void OnTriggerStay(Collider cubo )
    {
        if (cubo.gameObject.CompareTag(Cubo1))
        {
            Cont1 = 1;
            Debug.Log("Conteo "+ Cont1);
        }

        if (cubo.gameObject.CompareTag(Cubo2))
        {
            Cont2 = 1;
            Debug.Log("Conteo " + Cont2);
        }

        if (cubo.gameObject.CompareTag(Cubo3))
        {
            Cont3 = 1;
            Debug.Log("Conteo " + Cont3);
        }

        if (Cont1 == 1 && Cont2 == 1 && Cont3 == 1)
        {
            succesfulBanner.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider cubo)
    {
        if (cubo.gameObject.CompareTag(Cubo1))
        {
            Cont1 = 0;
            Debug.Log("Conteo " + Cont1);
        }

        if (cubo.gameObject.CompareTag(Cubo2))
        {
            Cont2 = 0;
            Debug.Log("Conteo " + Cont2);
        }

        if (cubo.gameObject.CompareTag(Cubo3))
        {
            Cont3 = 0;
            Debug.Log("Conteo " + Cont3);
        }

        if (Cont1 == 0 || Cont2 == 0 || Cont3 == 0)
        {
            succesfulBanner.gameObject.SetActive(false);
        }
    }

}
