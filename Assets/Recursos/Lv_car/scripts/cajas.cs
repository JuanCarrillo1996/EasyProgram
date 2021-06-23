using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cajas : MonoBehaviour
{
//public TextoVisualizador GUIText;
public int  recolectados = 0;
public int vuelta = 0;
public GameObject[] caja;

// SUPLANTAR BARRIL
//public GameObject objetoARecolectar;

void Start () {

}

 void Update () {
	
}

void OnTriggerEnter(Collider other){
	
        if( other.tag == "correcto")
        {
		other.gameObject.SetActive (false);
		recolectados++;
        Debug.Log(recolectados);

        }
        if( other.tag == "equivocado")
        {
		other.gameObject.SetActive (false);
        Debug.Log("Equivocado");
        restartGame();
        }
        if (recolectados == 8 && other.tag == "meta"){
            Debug.Log("vuelta completada");
            if( vuelta >= 1)
            {
                Debug.Log("fin del juego");
                SceneManager.LoadScene("lobby");
            }
            else
            {
                {
                vuelta++;
                again();
                }
            }
        }
	
}
public void restartGame(){
    SceneManager.LoadScene("level3");
}
public void again(){
        vuelta++;
        recolectados = 0;
      for (int i = 0; i < 8; i++)
    {
            caja[i].gameObject.SetActive (true);
    }
}



}
