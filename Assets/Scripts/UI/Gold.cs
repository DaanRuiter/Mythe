using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gold : MonoBehaviour {

	public Text goldText;
	
	public void UpdateUI(int score)
	{
		goldText.text = "" + score;
	}
}
