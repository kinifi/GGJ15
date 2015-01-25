using UnityEngine;
using System.Collections;

public class planetController : MonoBehaviour {

    public float countdownTimer = 2.0f;
    private int _currentScaleSize;
    public int scaleSizeToEndTimer = 10;
    private float secondaryTimer;

	// Use this for initialization
	void Start () {

        //set the secondary timer so we can reset later
        setSecondaryTimer();
	}
	
    /// <summary>
    /// sets the secondary timer to the first timer so we can reset the value later
    /// </summary>
    private void setSecondaryTimer()
    {
        secondaryTimer = countdownTimer;
    }

    /// <summary>
    /// Method that resets the timer after complete
    /// </summary>
    private void resetTimer()
    {
        countdownTimer = secondaryTimer;
    }

	// Update is called once per frame
	void Update () {

        //countdown the timer
        countdownTimer -= Time.deltaTime;
	
        //check if the timer is zero. We are checking this exactly because thats a hassle
        if(countdownTimer < 0)
        {
            TimerOnComplete();
        }

	}

    /// <summary>
    /// The method that is called when the timer reaches zero
    /// </summary>
    void TimerOnComplete()
    {
        resetTimer();
        scaleUp();
        Debug.Log("Timer Complete");
    }

    /// <summary>
    /// Scale up the local object that this script is attached to by x2
    /// </summary>
    void scaleUp()
    {
        if (_currentScaleSize != scaleSizeToEndTimer)
        {
            transform.localScale = new Vector2(transform.localScale.x + 1, transform.localScale.y + 1);
            _currentScaleSize++;
            Debug.Log("Scaling Up Planet");
        }
        else
        {
            OnScaleComplete();
        }
    }

    void OnScaleComplete()
    {
        Debug.Log("Earth is done scaling");
    }

}
