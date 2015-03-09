using UnityEngine;
using System.Collections;

public class Swipezone : MonoBehaviour {

    private bool _inArea;

    private void OnMouseEnter()
    {
        _inArea = true;
    }

    private void OnMouseExit()
    {
        _inArea = false;
    }

    public bool IsInArea()
    {
        return _inArea;
    }
}
