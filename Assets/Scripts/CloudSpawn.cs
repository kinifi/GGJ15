﻿using UnityEngine;
using System.Collections;

public class CloudSpawn : MonoBehaviour {

    public GameObject[] Clouds;
    public float timerBetweenSpawn = 1.0f;
    public float secondarySpawn;
	[System.NonSerialized]
    public Vector2 cloudRigidBodySpeed;

	// Use this for initialization
	void Start () {

        secondarySpawn = timerBetweenSpawn;
		cloudRigidBodySpeed = new Vector2(0.0f, 200.0f);

	}
	
	// Update is called once per frame
	void Update () {

        timerBetweenSpawn -= Time.deltaTime;

        if(timerBetweenSpawn < 0)
        {
            timerBetweenSpawn = secondarySpawn;
            TimerOnComplete();
        }

	}

    void TimerOnComplete()
    {
        SpawnCloud();
        //Debug.Log("Completed");
    }

    void SpawnCloud()
    {
        int _ranNum = Random.Range(0, Clouds.Length);
        GameObject _cloud;
        _cloud = Instantiate(Clouds[_ranNum], new Vector2(Random.Range(-3, 3), transform.position.y), transform.rotation) as GameObject;
        _cloud.AddComponent<Rigidbody>();
		_cloud.rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        _cloud.rigidbody.AddForce(cloudRigidBodySpeed);
        _cloud.rigidbody.useGravity = false;
    }
}
