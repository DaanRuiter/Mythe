using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Game : MonoBehaviour {

    public static Game instance;
    private Resources _resources;

    private void Awake()
    {
        instance = this;
        _resources = GameObject.FindGameObjectWithTag("Resources").GetComponent<Resources>();
    }

    public void HandleInteractable(Interactables interactable)
    {
        if(interactable.GetPickupType() == PickupType.gold)
        {
            //AddGold(interactable.GetPoints());
        }else if(interactable.GetPickupType() == PickupType.fish)
        {
            _resources.UpdateScore(interactable.GetPoints());
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
