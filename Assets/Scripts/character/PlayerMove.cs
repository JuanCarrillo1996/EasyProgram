using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float runSpeed = 1;
    public float rotationSpeed = 400.0f;

    private Animator animator;

    public float x, y, z;

    public Rigidbody rb;
    private float jumpHeight = 10f;
    public bool canJump;

    void Start()
    {
        canJump = false;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        y = 0;

        //Se declaran las variables del animador
        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", z);

        //Rota con el eje x y se mueve sobre el eje z
        transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);
        transform.Translate(0, 0, z * Time.deltaTime * runSpeed);

        //Animaciones conforme los movimientos presionados
        if (x != 0 || z != 0)
        {
            animator.SetBool("interact", false);
            animator.SetBool("Other", true);
        }

        //El personaje no seguirá haciendo la animación de correr cuando se presione W o S cuando ya no se mantenga presionado el botón de correr
        if (!Input.GetKey(KeyCode.Mouse1) && Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Other", true);
        }

        if (!Input.GetKey(KeyCode.Mouse1) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Other", true);
        }

        if (canJump && y==0)
        {
            //Correr
            if (Input.GetKey(KeyCode.Mouse1) && Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
            {
                animator.SetBool("Other", false);
                animator.Play("characterRunning");
            }


            //Girar al correr
            /*if (Input.GetKey(KeyCode.Mouse1) && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
            {
                animator.SetBool("Other", false);
                animator.Play("runArcLeft");
            }

            if (Input.GetKey(KeyCode.Mouse1) && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A))
            {
                animator.SetBool("Other", false);
                animator.Play("runArcRigth");
            }*/

            //Correr hacia atrás
            if (Input.GetKey(KeyCode.Mouse1) && Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
            {
                animator.SetBool("Other", false);
                animator.Play("runningBackward");
            }

            //Correr hacia la izquierda dando vueltas
            if (Input.GetKey(KeyCode.Mouse1) && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S))
            {
                animator.SetBool("Other", false);
                animator.Play("leftStrafeRun");
            }

            //Correr hacia la derecha dando vueltas
            if (Input.GetKey(KeyCode.Mouse1) && Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S))
            {
                animator.SetBool("Other", false);
                animator.Play("rightStrafeRun");
            }

            //Correr hacia atrás dando vueltas hacia la izquierda
            if (Input.GetKey(KeyCode.Mouse1) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.D))
            {
                animator.SetBool("Other", false);
                animator.Play("runBackwardArcLeft");
            }

            //Correr hacia atrás dando vueltas hacia la derecha
            if (Input.GetKey(KeyCode.Mouse1) && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A))
            {
                animator.SetBool("Other", false);
                animator.Play("runBackwardArcRight");
            }

            if (Input.GetKeyDown(KeyCode.Space) && !Input.GetKey(KeyCode.Mouse1))
            {
                animator.SetBool("jump", true);
                rb.AddForce(Vector3.up * jumpHeight , ForceMode.Impulse);
            }

            if (Input.GetKeyDown(KeyCode.Mouse0) && !Input.GetKey(KeyCode.Mouse1))
            {
                animator.SetBool("Other", false);
                animator.SetBool("interact", true);
                animator.Play("takeitem");
            }

            animator.SetBool("touchGround", true);
            
        }
        else
        {
            EstoyCayendo();
        }

    }

    public void EstoyCayendo()
    {
        animator.SetBool("touchGround", false);
        animator.SetBool("jump", false);
        y = 2;
    }

}