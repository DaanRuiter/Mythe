using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class displayUsernames : MonoBehaviour {

	public Text text;

	void Start () {
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
		Debug.Log(www.error);
	}
}
