using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class displayUsernames : MonoBehaviour {

	public Text text;

	public void Start()
	{
		downloadHighScore();
	}

	public void downloadHighScore () {
		string url = "http://16636.hosts.ma-cloud.nl/PHP/DisplayHighScore.php";
		WWW www = new WWW(url);
		StartCoroutine(WaitForRequest(www));
	}

	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;
		if (www.error == null)
		{
			text.text = www.text;
			Debug.Log(www.text);
		}
	}
}
