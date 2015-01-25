using UnityEngine;
using System.Collections;

public class LB_Submitter : MonoBehaviour {

    private static int scoreOne, scoreTwo, scoreThree, scoreFour, scoreFive;
	private static int currentScore;

	// Use this for initialization
	void Start () {
	 
	}

	public static void setCurrentScore(int _score)
	{
		if (PlayerPrefs.HasKey("currentScore"))
		{
			PlayerPrefs.SetInt("currentScore", 0);
		}
	}

	public static int getCurrentScore()
	{
		if (PlayerPrefs.HasKey("currentScore"))
		{
			int _score = PlayerPrefs.GetInt("currentScore");
			return _score;
		}
		else
		{
			Debug.LogWarning("Current Score Doesn't Exist");
			return 0;
		}
	}


	public static void submitScore(int _score)
    {
        loadScores();

        if(_score >= scoreFour)
        {
            if(_score >= scoreThree)
            {
                if (_score >= scoreTwo)
                {
                    if (_score >= scoreOne)
                    {
                        
                        //set to score Five
                        PlayerPrefs.SetInt("One", _score);
                    }
                    else
                    {
                        //set to score Four
                        PlayerPrefs.SetInt("Two", _score);
                    }
                }
                else
                {
                    //set to score three
                    PlayerPrefs.SetInt("Three", _score);
                }
            }
            else
            {
                //set to score two
                PlayerPrefs.SetInt("Four", _score);
            }
        }
        else
        {
            //set to score one
            PlayerPrefs.SetInt("Five", _score);
        }


    }

    private static void loadScores()
    {
        scoreOne = getScore("One");
        scoreTwo = getScore("Two");
        scoreThree = getScore("Three");
        scoreFour = getScore("Four");
        scoreFive = getScore("Five");

    }

    private static int getScore(string leaderboardName)
    {
        if (PlayerPrefs.HasKey(leaderboardName))
        {
            int _score = PlayerPrefs.GetInt(leaderboardName);
            return _score;
        }
        else
        {
            PlayerPrefs.SetInt(leaderboardName, 0);
            return 0;
        }
    }
}
