using UnityEngine;
using System.Collections;

public class ShootButton : MonoBehaviour {

    public HookShooter hook;

    private void OnMouseEnter()
    {
        print("enter");
    }

    private void OnMouseDown()
    {
        hook.ShootHarpoon();
    }
}
