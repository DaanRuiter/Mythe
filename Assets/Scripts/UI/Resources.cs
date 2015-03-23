using UnityEngine;
using System.Collections;

public class Resources : MonoBehaviour {

	private 	int 	_score;
    private     int     _scoreLeftToAdd;
	//private 	int 	_gold;

	private 	Score	_scoreUI;
	//private 	Gold 	_goldUI;
	
	void Awake()
	{
		_scoreUI 	= 	gameObject.GetComponent<Score>();
		//_goldUI 	= 	gameObject.GetComponent<Gold>();
	}

	void Start()
	{
		_scoreUI.UpdateUI(_score);
		//_goldUI.UpdateUI(_gold);
	}

	void Update()
	{
		if(_scoreLeftToAdd > 0)
        {
            _scoreLeftToAdd -= 1;
            _score += 1;
            _scoreUI.UpdateUI(_score);
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
        _scoreLeftToAdd += amount;
	}

	// ---------------------- Gold ----------------------
	//public int gold()
	/*{
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
	}*/
}
