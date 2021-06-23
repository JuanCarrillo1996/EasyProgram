using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootLogic : MonoBehaviour
{
    public PlayerMove playerMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        playerMove.canJump = true;
    }

    private void OnTriggerExit(Collider other)
    {
        playerMove.canJump = false;
    }

}
