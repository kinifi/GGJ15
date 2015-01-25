using UnityEngine;
using System.Collections;

public class loadSceneonButtonClick : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
	
	}

	public void loadLevel(string levelName)
	{
		Application.LoadLevel(levelName);
	}
}
