using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movimiento_automovil : MonoBehaviour
{
    public WheelCollider frontRight;
    public WheelCollider frontLeft;
    public WheelCollider rearRight;
    public WheelCollider rearLeft;
    public int aceleracion = 5000;
    public Rigidbody rb;
    public Transform NeumaticoRight;
    public Transform NeumaticoLeft;
    public int desAceleracion = 100;
    public int velocidadMaxima = 8000; 
    public float velocidad;
    



    // Audio
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
       // audioSource.pitch = 1;
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -1f, 0);
    }
    void Update(){
         if(Input.GetKey(KeyCode.I))
        {
            SceneManager.LoadScene("level3");
        }

        if (Input.GetKey(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("lobby");
        }


        if (Input.GetKey(KeyCode.W))
        {
            if (audioSource.pitch < 2)
            {
                audioSource.pitch += Time.deltaTime * 5 / 4;
            }      
             
        }else{
            audioSource.pitch = 1;
        }
        NeumaticoLeft.localEulerAngles = new Vector3(0, frontLeft.steerAngle * 1, 0);
        NeumaticoRight.localEulerAngles = new Vector3(0, frontRight.steerAngle * 1, 0);
         velocidad = (2 * Mathf.PI * rearRight.radius) * rearRight.rpm * 60/ 1000;
        velocidad = Mathf.Round (velocidad); 
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        // Avance el auto
        if (Mathf.Abs(velocidad) < velocidadMaxima)
        {
            rearRight.motorTorque = aceleracion * -Input.GetAxis("Vertical");
            rearLeft.motorTorque = aceleracion * -Input.GetAxis("Vertical");
        }else{
            rearRight.motorTorque = 0;
            rearLeft.motorTorque = 0;
        
        }

        if ( Input.GetAxis("Vertical") == 0 )
        {
            rearLeft.brakeTorque = desAceleracion;
            rearRight.brakeTorque =  desAceleracion;
        }else {
            rearLeft.brakeTorque = 0;
            rearRight.brakeTorque = 0;
        }


        // Giro del auto
        frontRight.steerAngle = 40 * Input.GetAxis("Horizontal");
        frontLeft.steerAngle = 40 * Input.GetAxis("Horizontal");
    }
}
