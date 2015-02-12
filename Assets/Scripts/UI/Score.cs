using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour 
{
	public Text scoreText;
	
	public void UpdateUI(int score)
	{
		scoreText.text = "Score: " + score;
	}
}
