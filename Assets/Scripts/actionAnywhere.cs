using UnityEngine;
using System.Collections;

public class actionAnywhere : MonoBehaviour {

	public string levelName = "HighScores";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.touchCount > 0 || Input.anyKeyDown || Input.GetMouseButtonDown(0))
		{
			Debug.Log("Loading HighScore Scene");
			Application.LoadLevel(levelName);

		}

	}
}
