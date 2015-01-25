using UnityEngine;
using System.Collections;

public class HealthSpawn : MonoBehaviour {

	//Configs
	public GameObject heart;
	public Vector2 heartRigidBodySpeed = new Vector2(0.0f, 200.0f);

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
		timerBetweenSpawn = Random.Range(15.0f, 45.0f); 
		heartRigidBodySpeed.y = Random.Range (175.0f, 225.0f);
		SpawnHealth();
		//Debug.Log("Completed");
	}

	private void SpawnHealth ()
	{
		//set up instatiation position
		Vector2 healthSpawnPosition = new Vector2(Random.Range(-3, 3), transform.position.y);
		healthSpawnPosition.y = -5.0f;

		GameObject _heart;
		_heart = Instantiate(heart, healthSpawnPosition, transform.rotation) as GameObject;
		_heart.AddComponent<Rigidbody>();
		_heart.rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
		_heart.rigidbody.AddForce(heartRigidBodySpeed);
		_heart.rigidbody.useGravity = false;
	}
}
