using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour {

	private int _timeRemaining;
	private Text _timeRemainingText;

	void Awake () 
	{
		_timeRemainingText = GetComponent<Text> ();

		startGame();
	}

	public void startGame()
	{
		_timeRemaining += 10;
		InvokeRepeating ("timeDown", 1f, 1f);
		_timeRemainingText.text =  "Time: " + _timeRemaining;// + timeRemaining;	//timeRemaining.ToString();

	}
	
	private void timeDown()
	{
		if(_timeRemaining == 0)
		{
			_timeRemainingText.text =  null;
			CancelInvoke();
			Application.LoadLevel("Shop");
			Debug.Log("Died");
		}
		else
		{
			_timeRemaining --;
			_timeRemainingText.text =  "Time: " + _timeRemaining;
		}
		Debug.Log (_timeRemaining);
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