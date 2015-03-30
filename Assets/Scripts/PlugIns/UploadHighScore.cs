using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UploadHighScore : MonoBehaviour {

	public InputField Username;
	public Text text;
	private int Score;

	void Start()
	{
		Score = PlayerPrefs.GetInt("Score");
		text.text = Score.ToString();
	}

	public void UploadScore()
	{
		string username = Username.text.ToString(); // Username for upload

		string score = Score.ToString(); // Score to upload
		string deviceId = SystemInfo.deviceUniqueIdentifier; // Device id for the saved screenshot

		string url = "http://16636.hosts.ma-cloud.nl/PHP/HighScoreForm.php";
		WWWForm form = new WWWForm();
		form.AddField("username", username);
		form.AddField("deviceId", deviceId);
		form.AddField("score", score);
		WWW www = new WWW(url, form);

		StartCoroutine(WaitForRequest(www));
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
	}
}