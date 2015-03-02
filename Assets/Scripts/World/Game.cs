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

    public void HandleInteractable(Interactables interactable)
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
