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

	protected Vector2 basePosition;

	protected override void Start()
	{
		base.Start();

		scale = new Vector2(transform.localScale.x, transform.localScale.y);

		startScale = transform.localScale.x;

		basePosition = transform.position;
	}

<<<<<<< HEAD
=======
    public void PickUp(Transform newParent)
    {
        transform.parent = newParent;
        hasBeenHooked = true;
    }

>>>>>>> 41cbbe2e7efc9cbd46cbaa8315f0a62c305073d3
    public int GetPointWorth()
    {
        return points;
    }
<<<<<<< HEAD
=======
//    public int GetPointWorth()
//    {
//        return fishPoints;
//    }
>>>>>>> 41cbbe2e7efc9cbd46cbaa8315f0a62c305073d3
}
