using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Scoring : MonoBehaviour {

	//Configs
	Text scoreValue;
	private float liveTime;
	private float pastTime = 0.0f;

	public int score;
	private int scoredPoints;

	public int multiplier = 1;
	public int pickUpMultiplier = 0;

	// Use this for initialization
	void Start () 
	{
		//Find teh ScoreValue text
		scoreValue = GameObject.Find ("ScoreValue").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Set the scored points value
		SetScoredPoints();
		//Calculate the score from time since level load
		CalculateScore();
		//Call the function to post the score
		PostScore();
	}

	private void SetScoredPoints ()
	{
		//Adjust the scoredPoints value based on time since level loaded
		if(liveTime > 60.0f)
		{
			scoredPoints = 3;
			//Debug.Log ("The scoredPoints value is 3");
		}
		else if(liveTime > 30.0f)
		{
			scoredPoints = 2;
			//Debug.Log("The scoredPoints value is 2");
		}
		else
		{
			scoredPoints = 1;
			//Debug.Log("The scoredPoints value is 1");
		}
	}

	private void CalculateScore ()
	{
		//Get the time since the level has loaded
		liveTime = Time.timeSinceLevelLoad;
		//Debug.Log ("This is the liveTime: "+liveTime);


		if(liveTime - pastTime > 2.0f)
		{
			//Calculate the score
			score = score + scoredPoints;
			//Debug.Log ("The score is: "+score);
			pastTime = liveTime;
		}
		else
		{
			//Score stays the same
			score = score;
		}
	}

	public void PostScore ()
	{
		//Convert the score as an int to a string and post
		scoreValue.text = score.ToString();
		//Debug.Log("Score has been posted!");
	}


}
