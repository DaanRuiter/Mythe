using UnityEngine;
using System.Collections;

public class FishPickup : Interactables 
{
	protected float radiusX;
	protected float radiusY;
	protected float x;
	protected float y;
	protected float startScale;

	protected Vector2 scale;
	protected Vector2 direction;
	
	protected override void Start()
	{
		base.Start();

		scale = new Vector2(transform.localScale.x, transform.localScale.y);

		startScale = transform.localScale.x;
	}

    public void PickUp(Transform newParent)
    {
        transform.parent = newParent;
        hasBeenHooked = true;
    }
<<<<<<< HEAD
=======

    public int GetPointWorth()
    {
        Debug.Log(points);
        return points;
    }
//    public int GetPointWorth()
//    {
//        return fishPoints;
//    }
>>>>>>> b31562559ebc2f5e219f8a65d1758c12fa62ea87
}
