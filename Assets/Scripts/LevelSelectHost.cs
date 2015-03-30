using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelSelectHost : MonoBehaviour {

	public Button[] buttons;
	private int levelAllowed = 19;
	private int currentLevel;


	// Use this for initialization
	void Start () 
	{
		currentLevel = PlayerPrefs.GetInt("highestLevel");

		for(int i = currentLevel;i < levelAllowed;i++)
		{
			buttons[i].image.overrideSprite = UnityEngine.Resources.Load<Sprite>("Lock");
			buttons[i].GetComponent<Button>().enabled = false;
		}
	
	}
}
