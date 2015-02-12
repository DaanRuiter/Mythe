using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Game : MonoBehaviour {

    public static Game instance;

    public Text pointText;

    private int _points;

    private void Awake()
    {
        instance = this;
    }

    public void AddScore(int pointsToAdd)
    {
        _points += pointsToAdd;
        pointText.text = "points: " + _points;
    }
}
