using UnityEngine;
using System.Collections;

public class UploadHighScore : MonoBehaviour {

	private bool isConnectedToInternet;

	public void uploadHighScore()
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
	}

/*	public void UploadScore()
	{
		if(isConnectedToInternet)
		{
			//create screenshot to upload

			yield return new WaitForEndOfFrame();
			
			
			int width = Screen.width;
			int height = Screen.height;
			Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);
			tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
			tex.Apply();
			byte[] bytes = tex.EncodeToPNG();
			Destroy(tex);

			string username = "Default"; // Username for upload
			string score = "1"; // Score to upload
			string deviceId = SystemInfo.deviceUniqueIdentifier; // Device id for the saved screenshot

			string url = "http://16636.hosts.ma-cloud.nl/PHP/HighScoreForm.php";
			WWWForm form = new WWWForm();
			form.AddField("username", username);
			form.AddField("deviceId", deviceId);
			form.AddField("score", score);
			form.AddBinaryData("fileToUpload", bytes);
			WWW www = new WWW(url, form);
			StartCoroutine(WaitForRequest(www));
		}
		else
			Debug.Log("Not connected to the internet...");
	}

	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;
		// check for errors
		if (www.error == null)
		{
			Debug.Log("WWW Ok!: " + www.text);
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}
	}*/
}