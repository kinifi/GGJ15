using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayGame ()
	{
		Debug.Log ("Loading the Main Level");
		Application.LoadLevel("Main");
	}

	public void ViewCredits ()
	{
		Debug.Log ("Loading the Credits Scene");
		Application.LoadLevel("Credits");
	}
}
