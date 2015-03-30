using UnityEngine;
using System.Collections;

public class VictoryCondition : MonoBehaviour {

    private int fishPointsNeeded;
    private int currentFishPoints;

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
            print(fishPointsNeeded);
            float pointsNeeded = (float)fishPointsNeeded / 100;
            print(pointsNeeded);
            fishPointsNeeded = (int)(pointsNeeded * (float) percentageOfTotalNeeded);
            print(fishPointsNeeded);
        }
        else
        {
            fishPointsNeeded = customFishpointsNeeded;
        }
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
