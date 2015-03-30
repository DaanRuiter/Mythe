using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {

    public static Stats instance;

	public int highScore;
	public int level;

	void Awake()
	{
		DontDestroyOnLoad(gameObject);
        instance = this;

		//Haal hier alle waarden uit de save game op.

		if(PlayerPrefs.HasKey("highScore"))
		{
			highScore = PlayerPrefs.GetInt("Score");
			print("Loaded score");
		}
		else
		{
			PlayerPrefs.SetInt("Score", 1);
			print("Loaded score");
		}

		if(PlayerPrefs.HasKey("highestLevel"))
		{
			level = PlayerPrefs.GetInt("highestLevel");
			print("Loaded level");
		}
		else
		{
			PlayerPrefs.SetInt("Level", 1);
			print("Loaded score");
		}

	}

	public void FinishLevel(int score)
	{
		highScore = PlayerPrefs.GetInt("Score");

		PlayerPrefs.SetInt("Score", score + highScore);

		if(PlayerPrefs.GetInt("highestLevel") <= Application.loadedLevel)
		{
			PlayerPrefs.SetInt("Level", Application.loadedLevel + 1);
		}
	}
}
