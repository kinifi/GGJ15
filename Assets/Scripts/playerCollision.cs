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
			GameObject.Find ("HitWhale").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find ("Whale").GetComponent<SpriteRenderer>().enabled = false;
			Invoke("DisableHit", 0.25f);
		}
		if(other.tag == "Health")
		{
			//Debug.Log("We're gaining health!");
			_health.CollectHeart();
			GameObject.Find ("HealthWhale").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find ("Whale").GetComponent<SpriteRenderer>().enabled = false;
			Invoke("DisableHealth", 0.25f);
			Destroy(other.gameObject, 0.05f);
		}
		if(other.tag == "Multiplier")
		{
			if(other.name == "x2multiplier(Clone)")
			{
				GameObject.Find ("x2Whale").GetComponent<SpriteRenderer>().enabled = true;
				GameObject.Find ("Whale").GetComponent<SpriteRenderer>().enabled = false;
				Invoke("DisableX2", 0.25f);
				Debug.Log ("We've collected an x2 multiplier!");
				_scoring.score = _scoring.score * 2;
				_scoring.PostScore();
				Destroy(other.gameObject, 0.05f);
			}
			else if(other.name == "x3multiplier(Clone)")
			{
				GameObject.Find ("x3Whale").GetComponent<SpriteRenderer>().enabled = true;
				GameObject.Find ("Whale").GetComponent<SpriteRenderer>().enabled = false;
				Invoke("DisableX3", 0.25f);
				Debug.Log ("We've collected an x3 multiplier!");
				_scoring.score = _scoring.score * 3;
				_scoring.PostScore();
				Destroy(other.gameObject, 0.05f);
			}
			else
			{
				Debug.Log ("Something went wrong with collecting a multiplier.");
				Destroy(other.gameObject, 0.05f);
			}
		}
		if(other.tag == "Flower")
		{
			_scoring.score = _scoring.score + 25;
			_scoring.PostScore();
			Destroy(other.gameObject, 0.05f);
		}
    }

	private void DisableHit ()
	{
		GameObject.Find ("HitWhale").GetComponent<SpriteRenderer>().enabled = false;
		GameObject.Find ("Whale").GetComponent<SpriteRenderer>().enabled = true;
	}

	private void DisableHealth ()
	{
		GameObject.Find ("HealthWhale").GetComponent<SpriteRenderer>().enabled = false;
		GameObject.Find ("Whale").GetComponent<SpriteRenderer>().enabled = true;
	}

	private void DisableX2 ()
	{
		GameObject.Find ("x2Whale").GetComponent<SpriteRenderer>().enabled = false;
		GameObject.Find ("Whale").GetComponent<SpriteRenderer>().enabled = true;
	}

	private void DisableX3 ()
	{
		GameObject.Find ("x3Whale").GetComponent<SpriteRenderer>().enabled = false;
		GameObject.Find ("Whale").GetComponent<SpriteRenderer>().enabled = true;
	}
}
