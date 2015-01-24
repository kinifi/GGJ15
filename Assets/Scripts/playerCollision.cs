using UnityEngine;
using System.Collections;

public class playerCollision : MonoBehaviour {

	//Components to get
	private Health _health;

	// Use this for initialization
	void Start () 
	{
		_health = GameObject.Find ("HealthImage").GetComponent<Health>();
	}
	
	void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
		if(other.tag == "Cloud")
		{
			//Debug.Log ("We've hit a cloud!");
			_health.TakeHit();
		}
		if(other.tag == "Health")
		{
			//Debug.Log("We're gaining health!");
			_health.CollectHeart();
		}
    }
}
