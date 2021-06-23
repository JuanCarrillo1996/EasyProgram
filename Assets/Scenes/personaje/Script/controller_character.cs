using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller_character : MonoBehaviour
{
    public float velociadaMovimiento = 3.0f;
    public float velocidadRotacion = 200.0f;
    private Animator anim;
    public float x, y;
    //Correr
    public int velCorrer;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            velociadaMovimiento = velCorrer;
            if(y > 0)
            {
                anim.SetBool("estado", true);
            }
            else
            {
                anim.SetBool("estado", false);
            }
        }else
        {
            velociadaMovimiento = 3.0f;
            anim.SetBool("estado", false);
        }
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velociadaMovimiento);

        anim.SetFloat("Velx", x);
        anim.SetFloat("Vely", y);
    }
}
