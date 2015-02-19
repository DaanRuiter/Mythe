using UnityEngine;
using System.Collections;

public class tijdelijkScriptVoorRecetLevel : MonoBehaviour {
	
	void Update () 
	{
		if(Input.GetKeyUp(KeyCode.R))
		{
			Application.LoadLevel(0);
		}
	}
}
