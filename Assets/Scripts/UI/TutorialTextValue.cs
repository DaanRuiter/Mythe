using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialTextValue : MonoBehaviour {

	private Text tutorialExplanation;
	public string[] tutorial;
	private int challenge;

	// Use this for initialization
	void Start () 
	{
		tutorialExplanation = GetComponent<Text>();

		tutorialExplanation.text = "Dit is een test";
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.A))
		{
			UpdateText(challenge);
		}
	}

	void UpdateText(int newText)
	{
		tutorialExplanation.text = tutorial[newText];
		challenge = newText;
	}
}
