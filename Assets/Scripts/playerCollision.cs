using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerCollision : MonoBehaviour {

	//Components to get
	private Health _health;
	private Scoring _scoring;

	// Use this for initialization
	void Start () 
	{
		_health = GameObject.Find ("HealthImage").GetComponent<Health>();
		_scoring = GameObject.Find ("Canvas").GetComponent<Scoring>();
	}

	void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);
		if(other.tag == "Cloud")
		{
			//Debug.Log ("We've hit a cloud!");
			_health.TakeHit();
		}
		if(other.tag == "Health")
		{
			//Debug.Log("We're gaining health!");
			_health.CollectHeart();
			Destroy(other.gameObject, 0.05f);
		}
		if(other.tag == "Multiplier")
		{

			if(other.name == "x2multiplier(Clone)")
			{
				Debug.Log ("We've collected an x2 multiplier!");
				_scoring.score = _scoring.score * 2;
				_scoring.PostScore();
				Destroy(other.gameObject, 0.05f);
			}
			else if(other.name == "x3multiplier(Clone)")
			{
				Debug.Log ("We've collected an x3 multiplier!");
				_scoring.score = _scoring.score * 3;
				_scoring.PostScore();
				Invoke ("ResetMultiplier", 2.05f);
			}
			else
			{
				Debug.Log ("Something went wrong with collecting a multiplier.");
				Destroy(other.gameObject, 0.05f);
			}
		}
    }

	private void ResetMultiplier ()
	{
		_scoring.pickUpMultiplier = 0;
	}
}
