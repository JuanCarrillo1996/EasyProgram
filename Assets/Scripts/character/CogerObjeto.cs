using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerObjeto : MonoBehaviour
{

    public GameObject handPoint;
    private GameObject pickerObject = null;

    // Update is called once per frame
    void Update()
    {

        if (pickerObject != null && Input.GetKeyDown(KeyCode.Mouse2))
        {

            pickerObject.GetComponent<Rigidbody>().useGravity = true;

            pickerObject.GetComponent<Rigidbody>().isKinematic = false;

            pickerObject.gameObject.transform.SetParent(null);

            pickerObject = null;

        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Objeto") || other.gameObject.CompareTag("Cubo1") || other.gameObject.CompareTag("Cubo2")
             || other.gameObject.CompareTag("Cubo3") || other.gameObject.CompareTag("Cubo4") || other.gameObject.CompareTag("Cubo5")
             || other.gameObject.CompareTag("Cubo6") || other.gameObject.CompareTag("Cubo7") || other.gameObject.CompareTag("Cubo8")
             || other.gameObject.CompareTag("Cubo9") || other.gameObject.CompareTag("Cubo10") || other.gameObject.CompareTag("Cubo11")
             || other.gameObject.CompareTag("Cubo12"))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && pickerObject == null)
            {

                StartCoroutine(WaitBeforeShow(other));

            }
        }
    }

    private IEnumerator WaitBeforeShow(Collider other)
    {
        Debug.Log("Se activa  WaitBeforeShow");
        yield return new WaitForSeconds(1);

        other.GetComponent<Rigidbody>().useGravity = false;

        other.GetComponent<Rigidbody>().isKinematic = true;

        other.transform.position = handPoint.transform.position;

        other.gameObject.transform.SetParent(handPoint.gameObject.transform);

        pickerObject = other.gameObject;

        Debug.Log("Sale de  WaitBeforeShow");
    }

}
