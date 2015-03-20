using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour 
{
	public GameObject tutorialPanel;
	public Text tutorialText;
	public GameObject harpoon;
	public GameObject boat;
	public GameObject handTouch;
	public GameObject handSwipe;

	public string[] tutorialTextenArray;
	private int currentTutorial;
	private float boatPosition;

	void Awake()
	{
		tutorialPanel.SetActive(true);
		nextTutorial(0);
	}
	void Update()
	{
		if(currentTutorial == 3)
		{
			if(harpoon.transform.position.y <= 0)
			{
				nextTutorial(4);
			}
		}
		else if(currentTutorial == 4)
		{
			if(boat.transform.position.x > boatPosition + 1f || boat.transform.position.x < boatPosition - 1f )
			{
				nextTutorial(5);
				
			}
		}
	}

	void nextButton()
	{
		nextTutorial(currentTutorial + 1);
	}

	void nextTutorial(int tutorialNumber)
	{
		tutorialPanel.SetActive(true);
		Time.timeScale = 0;
		tutorialText.text = tutorialTextenArray[tutorialNumber];
		currentTutorial = tutorialNumber;

		if(currentTutorial >= 3)
		{
			if(currentTutorial == 3)
			{
				handTouch.SetActive(true);
			}
			if(currentTutorial == 4)
			{
				handTouch.SetActive(false);
				handSwipe.SetActive(true);
				boatPosition = boat.transform.position.x;
			}
			if(currentTutorial == 5)
			{
				handSwipe.SetActive(false);
			}
		}
	}

	public void closeTutorial()
	{
		tutorialPanel.SetActive(false);
		Time.timeScale = 1;
		if(currentTutorial <3)
		{
			nextButton();
		}
	}
}