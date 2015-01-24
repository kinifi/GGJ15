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
		timerBetweenSpawn = Random.Range(5.0f, 10.0f); 
		heartRigidBodySpeed.y = Random.Range (200.0f, 300.0f);
		SpawnHealth();
		//Debug.Log("Completed");
	}

	private void SpawnHealth ()
	{
		GameObject _heart;
		_heart = Instantiate(heart, new Vector2(Random.Range(-3, 3), transform.position.y), transform.rotation) as GameObject;
		_heart.AddComponent<Rigidbody>();
		_heart.rigidbody.AddForce(heartRigidBodySpeed);
		_heart.rigidbody.useGravity = false;
	}
}
