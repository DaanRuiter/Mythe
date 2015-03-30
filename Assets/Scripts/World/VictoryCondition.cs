using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VictoryCondition : MonoBehaviour {

    private int fishPointsNeeded;
    private int currentFishPoints;

    public Text pointsNeededText;
    public int percentageOfTotalNeeded;
    public bool useCustomAmount;
    public int customFishpointsNeeded;

    private void Start()
    {
        if (!useCustomAmount)
        {
            GameObject[] fish = GameObject.FindGameObjectsWithTag("Interactable");
            for (int i = 0; i < fish.Length; i++)
            {
                fishPointsNeeded += fish[i].GetComponent<PointsAndTypes>().GetPoints();
            }
            float pointsNeeded = (float)fishPointsNeeded / 100;
            fishPointsNeeded = (int)(pointsNeeded * (float) percentageOfTotalNeeded);
        }
        else
        {
            fishPointsNeeded = customFishpointsNeeded;
        }
        pointsNeededText.text = "" + fishPointsNeeded;
    }

    public void AddFishPoints(int pointsToAdd)
    {
        currentFishPoints += pointsToAdd;
        if (hasWon)
        {
            //the player won the game.
        }
    }

    private bool hasWon
    {
        get
        {
            if (fishPointsNeeded <= currentFishPoints)
            {
                return true;
            }
            return false;
        }
    }

}
