using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	public Image head;
	public Button retry;
	public Text text;

	private void OnEnable()
    {
        Time.timeScale = 0;
    }

	public void endScreen(bool win)
	{
		Time.timeScale = 0;
		text.text = PlayerPrefs.GetInt("Score").ToString();
		if (win = true)
		{
			head.overrideSprite = UnityEngine.Resources.Load<Sprite>("Clear");
            //retry.image.overrideSprite = UnityEngine.Resources.Load<Sprite>("Next");

            PlayerPrefs.SetInt("highestLevel", PlayerPrefs.GetInt("highestLevel") + 1);
            PlayerPrefs.Save();
		}
	}

	public void mainMenu()
	{
		Time.timeScale = 1;
		Application.LoadLevel(0);
	}

	public void nextLevel()
	{
		Time.timeScale = 1;
		if(head.overrideSprite == UnityEngine.Resources.Load<Sprite>("Clear"))
		{
			Application.LoadLevel(Application.loadedLevel + 1);
		}
		else
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}