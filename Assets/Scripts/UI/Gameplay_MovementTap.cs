using UnityEngine;
using System.Collections;

public class Gameplay_MovementTap : MonoBehaviour {


    public float playerSpeed = 20.0f;
    private int movementIncrement = 0;
    private Animator _Anim;

	// Use this for initialization
	void Start () {

        _Anim = GameObject.Find("Whale").GetComponent<Animator>();
	}

    void Update()
    {
        #region keyboard detection
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            movePlayerLeft();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            movePlayerRight();
        }
        #endregion 

        if (Input.touchCount == 1)
        {
            var touch = Input.touches[0];
            if (touch.position.x < Screen.width / 2)
            {

                movePlayerLeft();
            }
            else if (touch.position.x > Screen.width / 2)
            {
                
                movePlayerRight();
            }
        }


    }

    void movePlayerLeft()
    {
        if (movementIncrement != -3)
        {
            transform.Translate(-1, 0, 0);
            movementIncrement -= 1;
            _Anim.SetTrigger("Left");
        }
    }

    void movePlayerRight()
    {
        if (movementIncrement != 3)
        {
            transform.Translate(1, 0, 0);
            movementIncrement += 1;
            _Anim.SetTrigger("Right");
        }
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
