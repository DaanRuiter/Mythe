using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Game : MonoBehaviour {

    public static Game instance;

    public Text pointText;
    public Text goldText;

    public int points;
    public int gold;

    private void Awake()
    {
        instance = this;
    }

    public void AddScore(int pointsToAdd)
    {
        points += pointsToAdd;
        pointText.text = "Points: " + points;
    }

    public void AddGold(int goldToAdd)
    {
        gold += goldToAdd;
        goldText.text = "Gold: " + gold;
    }

    public void SetStats(int gold , int points)
    {
        this.points = points;
        this.gold = gold;
        pointText.text = "Points: " + points;
        goldText.text = "Gold: " + gold;
    }
}

public class Level : MonoBehaviour
{
    public int index;
    public int fishNeededToAdvance;
    public int pointsAquired;
    public int goldAquired;
}
