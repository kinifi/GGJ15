using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LB_Reader : MonoBehaviour {

    public string m_LeaderboardName;
    public int m_Score;
    private Text _ScoreDisplay;

	// Use this for initialization
	void Start () {

		_ScoreDisplay = GetComponent<Text>();
		loadScore();

	}
	
    void loadScore()
    {
        if(PlayerPrefs.HasKey(m_LeaderboardName))
        {
            m_Score = PlayerPrefs.GetInt(m_LeaderboardName);
            setScore();
        }
        else
        {
            Debug.Log("Leaderboard: " + m_LeaderboardName + " does not exist.");
            Debug.Log("Creating: " + m_LeaderboardName);
            PlayerPrefs.SetInt(m_LeaderboardName, 0);
            loadScore();
        }
       
    }

    void setScore()
    {
        _ScoreDisplay.text = m_Score + "";
    }
}
