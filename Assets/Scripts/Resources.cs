using UnityEngine;
using System.Collections;

public class Resources : MonoBehaviour {

	private 	int 	_score;
	private 	int 	_gold;

	private 	Score	_scoreUI;
	private 	Gold 	_goldUI;
	
	void Awake()
	{
		_scoreUI 	= 	gameObject.GetComponent<Score>();
		_goldUI 	= 	gameObject.GetComponent<Gold>();
	}

	void Start()
	{
		_scoreUI.UpdateUI(_score);
		_goldUI.UpdateUI(_gold);
	}

	void Update()
	{
		if(Input.GetKeyUp(KeyCode.G))
		{
			UpdateGold(10);
		}

		if(Input.GetKeyUp(KeyCode.S))
		{
			UpdateScore(10);
		}
	}

	// ---------------------- Score ----------------------
	public int score()
	{
		return _score;
	}
	
	public void SetScore(int amount)
	{
		_score = amount;
		_scoreUI.UpdateUI(_score);
	}
	
	public void UpdateScore(int amount)
	{
		_score += amount;
		_scoreUI.UpdateUI(_score);
	}

	// ---------------------- Gold ----------------------
	public int gold()
	{
		return _gold;
	}
	
	public void SetGold(int amount)
	{
		_gold = amount;
		_goldUI.UpdateUI(_gold);
	}
	
	public void UpdateGold(int amount)
	{
		_gold += amount;
		_goldUI.UpdateUI(_gold);
	}
}
