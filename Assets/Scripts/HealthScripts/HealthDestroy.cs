using UnityEngine;
using System.Collections;

public class HealthDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		//Be sure to kill the object
		//Debug.Log ("This health pickup will self destruct in 10 seconds.");
		Destroy (this.gameObject, 5.0f);
	}
}
