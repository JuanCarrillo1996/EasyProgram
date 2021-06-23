using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{

    public float velocidadRotacion = 200.0f;
    public float x;

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);

    }
}
