using UnityEngine;
using System.Collections;

public class playerCollision : MonoBehaviour {

	//Components to get
	private Health _hit;

	// Use this for initialization
	void Start () 
	{
		_hit = GameObject.Find ("HealthImage").GetComponent<Health>();
	}
	
	void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
		if(other.tag == "Cloud")
		{
			Debug.Log (" 
		}
    }
}
