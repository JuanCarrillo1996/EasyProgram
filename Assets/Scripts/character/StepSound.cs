using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSound : MonoBehaviour
{

    public AudioSource Pie;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Terrain"))
        {
            Pie.Play();
        }
    }
}
