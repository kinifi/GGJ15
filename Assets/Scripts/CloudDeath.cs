using UnityEngine;
using System.Collections;

public class CloudDeath : MonoBehaviour {

    private float deathTimer = 5.0f;

	// Use this for initialization
	void Start () {

        Invoke("deathOnComplete", deathTimer);

	}
	
	void deathOnComplete() {
        Destroy(this.gameObject);
    }
}
