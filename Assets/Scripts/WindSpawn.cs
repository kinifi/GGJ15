using UnityEngine;
using System.Collections;

public class WindSpawn : MonoBehaviour {

	//Configs
	private float gameTime;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		gameTime = Time.timeSinceLevelLoad;

		//Adjust the scoredPoints value based on time since level loaded
		if(gameTime > 60.0f)
		{
			scoredPoints = 3;
			//Debug.Log ("The scoredPoints value is 3");
		}
		else if(gameTime > 30.0f)
		{
			scoredPoints = 2;
			//Debug.Log("The scoredPoints value is 2");
		}
	}


}
