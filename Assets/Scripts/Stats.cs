using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {

	void Awake()
	{
		DontDestroyOnLoad(gameObject);

		//Haal hier alle waarden uit de save game op.
	}
}
