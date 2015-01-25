using UnityEngine;
using System.Collections;

public class WindSpawn : MonoBehaviour {

	//Configs
	private float gameTime;
	private Vector2 _cloudSpeed;
	private bool canSpawnWind = false;
	public GameObject[] Winds;
	public Vector2 windRigidBodySpeed = new Vector2(0.0f, 200.0f);
	private float timerBetweenSpawn = 5.0f;
	private float secondarySpawn;

	// Use this for initialization
	void Start () 
	{
		_cloudSpeed = GameObject.Find("CloudSpawner").GetComponent<CloudSpawn>().cloudRigidBodySpeed;
		//set the countdown spawner to the con
		secondarySpawn = timerBetweenSpawn;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//update the game time variable
		gameTime = Time.timeSinceLevelLoad;
				//Adjust the cloud speed value based on time since level loaded
		if(gameTime > 60.0f)
		{
			_cloudSpeed = new Vector2(0.0f, 300.0f);
			canSpawnWind = true;
			windRigidBodySpeed = new Vector2(0.0f, 250.0f);
			//Debug.Log("The cloudSpeed is now 300");
		}
		else if(gameTime > 30.0f)
		{
			_cloudSpeed = new Vector2(0.0f, 250.0f);
			canSpawnWind = true;
			//Debug.Log("The cloudSpeed is now 250");
		}
		else
		{
			_cloudSpeed = new Vector2(0.0f, 200.0f);
			canSpawnWind = false;
			//Debug.Log("The cloudSpeed is now 200");
		}

		//Update wind spawning timers
		timerBetweenSpawn -= Time.deltaTime;
		if(timerBetweenSpawn < 0)
		{
			timerBetweenSpawn = secondarySpawn;
			TimerOnComplete();
		}
	}

	void TimerOnComplete()
	{
		timerBetweenSpawn = Random.Range(15.0f, 45.0f); 
		windRigidBodySpeed.y = Random.Range (175.0f, 225.0f);
		if(canSpawnWind == true)
		{
			//Debug.Log ("canSpawnWind is true!");
			SpawnWind();
		}

		//Debug.Log("Wind Timer Completed");
	}

	void SpawnWind()
	{
		//set up instatiation position
		Vector2 windSpawnPosition = new Vector2(Random.Range(-3, 3), transform.position.y);
		windSpawnPosition.y = -5.0f;

		int _ranNum = Random.Range(0, Winds.Length);
		GameObject _wind;
		_wind = Instantiate(Winds[_ranNum], windSpawnPosition, transform.rotation) as GameObject;
		_wind.AddComponent<Rigidbody>();
		_wind.rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
		_wind.rigidbody.AddForce(windRigidBodySpeed);
		_wind.rigidbody.useGravity = false;
	}


}
