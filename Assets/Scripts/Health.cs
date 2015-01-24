using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour {

	//Configs
	public Sprite[] healthStatuses;
	private Image _healthImage;
	private int healthValue = 5;

	// Use this for initialization
	void Start () 
	{
		_healthImage = GameObject.Find ("HealthImage").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TakeHit ()
	{
		if(healthValue - 1 >= 0)
		{
			healthValue -= 1;
			UpdateHealthImage(healthValue);
		}
		else
		{
			healthValue = 0;
			UpdateHealthImage(healthValue);
		}
	}

	private void UpdateHealthImage (int healthValue)
	{
		switch(healthValue)
		{
		case 0:
			_healthImage.sprite = healthStatuses[0];
			Debug.Log("The health value is 0.");
			break;
		case 1:
			_healthImage.sprite = healthStatuses[1];
			Debug.Log ("The health value is 1.");
			break;
		case 2:
			_healthImage.sprite = healthStatuses[2];
			Debug.Log("The health value is 2.");
			break;
		case 3:
			_healthImage.sprite = healthStatuses[3];
			Debug.Log ("The health value is 3.");
			break;
		case 4:
			_healthImage.sprite = healthStatuses[4];
			Debug.Log("The health value is 4.");
			break;
		case 5:
			_healthImage.sprite = healthStatuses[5];
			Debug.Log("The health value is 5.");
			break;
		default:
			_healthImage.sprite = healthStatuses[5];
			healthValue = 5;
			Debug.Log ("The health value has defaulted to 5.");
			break;
		}
	}
}