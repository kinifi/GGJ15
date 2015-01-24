using UnityEngine;
using System.Collections;

public class Gameplay_MovementTap : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            movePlayerLeft();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            movePlayerRight();
        }


    }

    void movePlayerLeft()
    {
        this.rigidbody.AddForce(new Vector3(-10, 0, 0));
    }

    void movePlayerRight()
    {
        this.rigidbody.AddForce(new Vector3(10, 0, 0));
    }

    #region touch Public Methods
    public void MoveLeft()
    {
        movePlayerLeft();
        Debug.Log("Move Left");
    }

    public void MoveRight()
    {
        movePlayerRight();
        Debug.Log("Move Right");
    }
    #endregion


}
