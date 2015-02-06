using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour {

	private int _timeRemaining = 10;
	private Text _timeRemainingText;

	// Use this for initialization
	void Awake () 
	{
		_timeRemainingText = GetComponent<Text> ();
		_timeRemainingText.text =  "" + _timeRemaining;// + timeRemaining;	//timeRemaining.ToString();
		
		InvokeRepeating ("timeDown", 1f, 1f);
	}
	
	private void timeDown()
	{
		if(_timeRemaining == 0)
		{
			//Application.LoadLevel(/*lose screen*/);
			Debug.Log("Died");
		}
		else
			_timeRemaining --;

		_timeRemainingText.text =  "" + _timeRemaining;// + timeRemaining;	//timeRemaining.ToString();
		Debug.Log (_timeRemaining);
	}
}
