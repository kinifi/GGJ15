using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Scoring : MonoBehaviour {

	//Configs
	Text scoreValue;
	private float liveTime;
	private float rawScore;
	private int score;

	// Use this for initialization
	void Start () 
	{
		scoreValue = GameObject.Find ("ScoreValue").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		CalculateScore();
	}

	private void CalculateScore ()
	{
		//Get the time since the level has loaded
		liveTime = Time.timeSinceLevelLoad;
		//Debug.Log ("This is the liveTime: "+liveTime);

		//Calculate the score and round
		rawScore = (liveTime%10.0f)+10.0f;
		//Debug.Log ("The score is: "+score);

		//Convert score to int
		score = (int)rawScore;
		//Debug.Log ("The score as an int is: " + score);

		//Call the function to post the score
		PostScore(score);
	}

	private void PostScore (int score)
	{
		//Convert the score as an int to a string and post
		scoreValue.text = score.ToString();
		//Debug.Log("Score has been posted!");
	}


}
