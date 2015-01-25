 using UnityEngine;
using System.Collections;

public class MultiplierSpawn : MonoBehaviour {

	//Configs
	public GameObject[] multiplierArray;
	private GameObject multiplier;
	public Vector2 multiplierRigidBodySpeed = new Vector2(0.0f, 200.0f);
	
	private float timerBetweenSpawn = 5.0f;
	private float secondarySpawn;

	// Use this for initialization
	void Start () 
	{
		//set the countdown spawner to the con
		secondarySpawn = timerBetweenSpawn;
	}
	
	// Update is called once per frame
	void Update () 
	{
		timerBetweenSpawn -= Time.deltaTime;
		
		if(timerBetweenSpawn < 0)
		{
			timerBetweenSpawn = secondarySpawn;
			TimerOnComplete();
		}
	}

	void TimerOnComplete()
	{
		timerBetweenSpawn = Random.Range(15.0f, 30.0f); 
		multiplierRigidBodySpeed.y = Random.Range (250.0f, 275.0f);
		SpawnMultiplier();
		//Debug.Log("Completed");
	}

	private void SpawnMultiplier ()
	{
		//set up instatiation position
		Vector2 multiplierSpawnPosition = new Vector2(Random.Range(-3, 3), transform.position.y);
		multiplierSpawnPosition.y = -5.0f;

		//pick multiplier values
		int multiplierPicker = Random.Range (0,10);
		if(multiplierPicker > 7)
		{
			//if greater than seven, pick x3
			multiplier = multiplierArray[1];
		}
		else
		{
			//if less than seven, pick x2
			multiplier = multiplierArray[0];
		}
		
		GameObject _multiplier;
		_multiplier = Instantiate(multiplier, multiplierSpawnPosition, transform.rotation) as GameObject;
		_multiplier.AddComponent<Rigidbody>();
		_multiplier.rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
		_multiplier.rigidbody.AddForce(multiplierRigidBodySpeed);
		_multiplier.rigidbody.useGravity = false;
	}
}
