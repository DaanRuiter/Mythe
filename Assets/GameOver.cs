using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	public Button head;
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
			head.image.overrideSprite = UnityEngine.Resources.Load<Sprite>("Clear");
			//retry.image.overrideSprite = UnityEngine.Resources.Load<Sprite>("Next");
		}
		else
		{

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
		if(head.image.overrideSprite == UnityEngine.Resources.Load<Sprite>("Clear"))
		{
			Application.LoadLevel(Application.loadedLevel + 1);
		}
		else
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}