using UnityEngine;
using System.Collections;

public class VictoryCondition : MonoBehaviour {

    public int fishPointsNeeded;
    private int currentFishPoints;

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
