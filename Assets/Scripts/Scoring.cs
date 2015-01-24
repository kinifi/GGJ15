using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Scoring : MonoBehaviour {

	//Configs
	Text scoreValue;
	private float liveTime;
	private int score;

	public int multiplier = 1;

	// Use this for initialization
	void Start () 
	{
		scoreValue = GameObject.Find ("ScoreValue").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		//Set the multiplier
		SetMultiplier();
		//Calculate the score from time since level load
		CalculateScore();
		//Call the function to post the score
		PostScore();
	}

	private void SetMultiplier ()
	{
		//Adjust the multiplier based on the time since level loaded
		if(liveTime > 60.0f)
		{
			multiplier = 3;
			//Debug.Log ("The multiplier is 3");
		}
		else if(liveTime > 30.0f)
		{
			multiplier = 2;
			//Debug.Log("The multiplier is 2");
		}
		else
		{
			multiplier = 1;
			//Debug.Log ("The multiplier is 1");
		}
	}

	private void CalculateScore ()
	{
		//Get the time since the level has loaded
		liveTime = Time.timeSinceLevelLoad;
		//Debug.Log ("This is the liveTime: "+liveTime);
		
		//Calculate the score
		score = (Mathf.RoundToInt((liveTime/2.0f)) * multiplier);
		//Debug.Log ("The score is: "+score);
	}

	private void PostScore ()
	{
		//Convert the score as an int to a string and post
		scoreValue.text = score.ToString();
		//Debug.Log("Score has been posted!");
	}


}
