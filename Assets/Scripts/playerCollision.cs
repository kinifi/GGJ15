﻿using UnityEngine;
using System.Collections;

public class playerCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
    }
}
