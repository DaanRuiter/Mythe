using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour {

	private int _timeRemaining;
	private int _totalTime; 
	//private Slider slider;

	void Awake () 
	{
		//_timeRemainingText = GetComponent<Text> ();

		startGame();
	}

	public void startGame()
	{
		_totalTime = 100;
		//slider = gameObject.GetComponent<Slider>();
		//slider.maxValue = 100;
		_timeRemaining = _totalTime;

		InvokeRepeating ("timeDown", 1f, 1f);
		//_timeRemainingText.text =  "Time: " + _timeRemaining;// + timeRemaining;	//timeRemaining.ToString();
	}
	
	public void timeDown()
	{
		if(_timeRemaining == 0)
		{
			//Gaat naar een ander level. bijvoorbeeld shop/deadscreen.
			CancelInvoke();
			Application.LoadLevel("Menu");
			Debug.Log("Died");
		}
		else
		{

			_timeRemaining --;
			transform.Rotate(0,0,-3);//100/360 kan niet, komt op 0 uit.(achter de comma word niet mee gerekend)
		}
	}

	void OnLevelWasLoaded(int level) 
	{
		//prepare each scene for startup.
		if(level != 1)
		{
			startGame();
		}
	}
}