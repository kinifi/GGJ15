using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class planetController : MonoBehaviour {

    public float countdownTimer = 2.0f;
    private int _currentScaleSize;
    public int scaleSizeToEndTimer = 10;
    private float secondaryTimer;
	private Animator _anim;
	//public GameObject LeaderboardPanel;
	private Transform _player, _planet;
	private bool canCountDown = false;

	// Use this for initialization
	void Start () {

		_anim = GetComponent<Animator>();

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

		if(!canCountDown)
		{
	        //countdown the timer
	        countdownTimer -= Time.deltaTime;
		
	        //check if the timer is zero. We are checking this exactly because thats a hassle
	        if(countdownTimer < 0)
	        {
	            TimerOnComplete();

	        }
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
			canCountDown = true;
        }
    }

    void OnScaleComplete()
    {
        Debug.Log("Earth is done scaling");
		Destroy(GameObject.Find("CloudSpawner"));
		Destroy(GameObject.Find("HealthSpawner"));
		Destroy(GameObject.Find("MultiplierSpawner"));
		_planet = GameObject.Find("Planet").transform;
		_player = GameObject.Find("Player").transform;

		if(_planet != null || _player != null)
		{
			Debug.Log("start moving and scaling Player");
			iTween.MoveTo(_player.gameObject, iTween.Hash("position", new Vector3(_planet.position.x, _planet.position.y, _planet.position.z), "time", 1.0f, "oncompletetarget", this.gameObject, "oncomplete", "scalePlayer"));

		}

    }

	void scalePlayer()
	{
		Transform _player = GameObject.Find("Player").transform;
		//_player.gameObject.SetActive(false);
		audio.Play();
		_anim.SetTrigger("Splash");
		Invoke("leaderboard", 0.5f);
	}

	void leaderboard()
	{
		//LeaderboardPanel.SetActive(true);
		Debug.Log("Leaderboard Score to Submit: " + int.Parse((GameObject.Find("ScoreValue").GetComponent<Text>().text)));
		LB_Submitter.submitScore(int.Parse((GameObject.Find("ScoreValue").GetComponent<Text>().text)));
		Application.LoadLevel("Highscores");
	}

}
