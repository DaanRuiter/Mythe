using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(VictoryCondition))]
public class Game : MonoBehaviour {

    public static Game instance;

    private VictoryCondition _victoryCondidtion;

    public Text pointText;
    public Text goldText;

    public int points;
    public int gold;

    private void Awake()
    {
        instance = this;
        _victoryCondidtion = GetComponent<VictoryCondition>();
    }

    public void AddScore(int pointsToAdd)
    {
        _victoryCondidtion.AddFishPoints(pointsToAdd);
        points += pointsToAdd;
        pointText.text = "" + points;
    }

    public void AddGold(int goldToAdd)
    {
        gold += goldToAdd;
        goldText.text = "" + gold;
    }

    public void SetStats(int gold , int points)
    {
        this.points = points;
        this.gold = gold;
        pointText.text = "" + points;
        goldText.text = "" + gold;
    }

    public void HandleInteractable(PointsAndTypes interactable)
    {
        if(interactable.GetPickupType() == PickupType.gold)
        {
            AddGold(interactable.GetPoints());
        }else if(interactable.GetPickupType() == PickupType.fish)
        {
            AddScore(interactable.GetPoints());
        }
    }
}

public class Level : MonoBehaviour
{
    public int index;
    public int fishNeededToAdvance;
    public int pointsAquired;
    public int goldAquired;
}
