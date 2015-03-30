using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour {

	private float _timeRemaining;
	public float _totalTime; 

	void Awake () 
	{
		startGame();
	}

	public void startGame()
	{
		_timeRemaining = _totalTime;

		InvokeRepeating ("timeDown", 1f, 1f);
	}
	
	public void timeDown()
	{
		if(_timeRemaining == 0)
		{
			//Gaat naar een ander level. bijvoorbeeld shop/deadscreen.
			CancelInvoke();
		}
		else
		{
			_timeRemaining --;
			transform.Rotate(0,0,-(360/_totalTime));
		}
	}
}