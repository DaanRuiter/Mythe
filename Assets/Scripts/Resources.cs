using UnityEngine;
using System.Collections;

public class Resources : MonoBehaviour {

	private int _score;
	private Score _scoreUI;
	
	void Awake()
	{
		_scoreUI = gameObject.GetComponent<Score>();
	}

	void Start()
	{
		_scoreUI.UpdateUI(_score);
	}
	
	public int score()
	{
		return _score;
	}
	
	public void SetScore(int amount)
	{
		_score = amount;
	}
	
	public void UpdateScore(int amount)
	{
		_score += amount;
	}
}
