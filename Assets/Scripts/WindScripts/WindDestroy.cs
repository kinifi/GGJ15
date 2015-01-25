using UnityEngine;
using System.Collections;

public class WindDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		//Be sure to kill the object
		//Debug.Log ("This wind gust will self destruct in 5 seconds.");
		Destroy (this.gameObject, 5.0f);
	}
}
