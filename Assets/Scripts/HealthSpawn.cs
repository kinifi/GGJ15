using UnityEngine;
using System.Collections;

public class HealthSpawn : MonoBehaviour {

	public GameObject heart;
	public Vector2 heartRigidBodySpeed;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void Spawn ()
	{
		GameObject _heart;
		_heart = Instantiate(heart, new Vector2(Random.Range(-3, 3), transform.position.y), transform.rotation) as GameObject;
		_heart.AddComponent<Rigidbody>();
		_heart.rigidbody.AddForce(heartRigidBodySpeed);
		_heart.rigidbody.useGravity = false;
	}
}
