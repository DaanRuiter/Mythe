using UnityEngine;
using System.Collections;

public class UploadHighScore : MonoBehaviour {

	private bool isConnectedToInternet;

	void Awake()
	{
		checkInternet();
	}

	public void checkInternet()
	{
		isConnectedToInternet = false;
		
		if (Network.player.ipAddress.ToString() != "0.0.0.0")
		{
			isConnectedToInternet = true;      
		}

		Debug.Log(isConnectedToInternet);
	}

	public void UploadScore()
	{
		if(isConnectedToInternet)
		{
			/*Script for uploading your score here*/
		}
		else
			Debug.Log("Not connected to the internet...");
	}


}
