using UnityEngine;
using System.Collections;

public class ShopScript : MonoBehaviour {

	public GameObject[] canvas;
	private int lastScreen;

	void Awake()
	{
		lastScreen = 0;
	}

	public void canvasHost(int nextScreen)
	{
		canvas[nextScreen].SetActive(true);
		canvas[lastScreen].SetActive(false);
		lastScreen = nextScreen;
	}
}
