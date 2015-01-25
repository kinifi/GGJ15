using UnityEngine;
using System.Collections;

public class FlowerSpawn : MonoBehaviour {

	public GameObject Flower;
	public float timerBetweenSpawn = 1.0f;
	private float secondarySpawn;
	[System.NonSerialized]
	public Vector2 flowerRigidBodySpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
