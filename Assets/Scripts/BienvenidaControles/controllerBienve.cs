using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class controllerBienve : MonoBehaviour
{
        [Header("Paneles")]
        [SerializeField] private GameObject Controles;
        [SerializeField] private GameObject Bienvenida;

        [Header("Escena juego")]
        public string juego;
        public int bandera = 0;
        private void Start()
        {
            Bienvenida.SetActive(true);
            Controles.SetActive(false); 
        }


        private void Update()
        {
                 
        if(Input.GetKeyDown(KeyCode.Mouse0) && bandera == 0 ){
            Bienvenida.SetActive(false);
            Controles.SetActive(true);
            bandera = 1;
            Debug.Log("cambio escene");
            

        }
        else if(Input.GetKeyDown(KeyCode.Mouse0) && bandera == 1 ){
            StartCoroutine(next());
        }
        
        } 

        public IEnumerator next()
        {
            yield return new WaitForSeconds(5);
            Debug.Log("Ultima escena");
           Bienvenida.SetActive(false);
           Controles.SetActive(false); 
           SceneManager.LoadScene(juego);  
        }
}
