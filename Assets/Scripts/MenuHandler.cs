using UnityEngine;
using System.Collections;

public class MenuHandler : MonoBehaviour {

	public GameObject[] canvas;

	public void startGame()
	{
		Application.LoadLevel(1);
	}

	public void quitGame()
	{
		Application.Quit();
	}

	public void Menu()
	{
		canvas[1].SetActive(false);
		canvas[0].SetActive(true);
	}

	public void Credits()
	{
		canvas[0].SetActive(false);
		canvas[1].SetActive(true);
	}
}
