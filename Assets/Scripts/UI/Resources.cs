using UnityEngine;
using System.Collections;

public class Resources : MonoBehaviour {

	private 	int 	_score;
	//private 	int 	_gold;

	//private 	Gold 	_goldUI;
	
	void Awake()
	{
		//_goldUI 	= 	gameObject.GetComponent<Gold>();
	}

	void Start()
	{
		//_goldUI.UpdateUI(_gold);
	}

	/*void Update()
	{
		if(Input.GetKeyUp(KeyCode.G))
		{
			UpdateGold(10);
		}

		if(Input.GetKeyUp(KeyCode.S))
		{
			UpdateScore(10);
		}
	}*/

	// ---------------------- Score ----------------------
	public int score()
	{
		return _score;
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
