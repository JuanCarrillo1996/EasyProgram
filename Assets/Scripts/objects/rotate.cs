﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {

	public float rotateVelocity = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.Rotate(new Vector3(0f, Time.deltaTime*(10+ rotateVelocity), 0f)); //Rotar el cubo

	}
}
