using UnityEngine;
using System.Collections;

public class FlowerSpawn : MonoBehaviour {

	public GameObject Flower;
	private float timerBetweenSpawn = 3.0f;
	private float secondarySpawn;
	private Vector2 flowerRigidBodySpeed;

	// Use this for initialization
	void Start () 
	{
		secondarySpawn = timerBetweenSpawn;
		flowerRigidBodySpeed = new Vector2(0.0f, 200.0f);
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
		SpawnFlower();
		//Debug.Log("Completed");
	}

	void SpawnFlower()
	{
		//set up instatiation position
		Vector2 flowerSpawnPosition = new Vector2(Random.Range(-3, 3), transform.position.y);
		flowerSpawnPosition.y = -5.0f;

		GameObject _flower;
		_flower = Instantiate(Flower, flowerSpawnPosition, transform.rotation) as GameObject;
		_flower.rigidbody.AddForce(flowerRigidBodySpeed);
		_flower.rigidbody.useGravity = false;
	}
}
