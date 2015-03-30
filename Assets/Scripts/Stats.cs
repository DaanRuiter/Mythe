using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {

    public static Stats instance;

	public int highScore;
    public int level;

	void Awake()
    {
        instance = this;
		DontDestroyOnLoad(gameObject);

        print(PlayerPrefs.GetInt("Level"));

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
        PlayerPrefs.Save();

	}

	public void FinishLevel(int score)
	{
		highScore = PlayerPrefs.GetInt("Score");

		PlayerPrefs.SetInt("Score", score + highScore);

        Game.instance.gameOverScreen.SetActive(true);
	}
}
