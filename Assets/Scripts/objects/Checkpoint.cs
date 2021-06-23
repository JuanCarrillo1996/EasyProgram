using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public Transform player;
    public Transform checkPoint;

    private void OnTriggerStay(Collider cubo)
    {

        if (cubo.gameObject.CompareTag("Player"))
        {
            player.position = checkPoint.position;
        }
  
    }
}
