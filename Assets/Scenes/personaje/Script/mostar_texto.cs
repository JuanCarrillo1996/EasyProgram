using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mostar_texto : MonoBehaviour
{
    public float TiempoTexto = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        TiempoTexto -= Time.deltaTime;
        if(TiempoTexto <= 0)
        {
            Destroy(this.gameObject);
        }





    }
}
