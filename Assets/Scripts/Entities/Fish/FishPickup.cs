using UnityEngine;
using System.Collections;

public class FishPickup : Interactables 
{
	protected float speed;
	protected float mathSpeed;
	protected float radiusX;
	protected float radiusY;
	protected float x;
	protected float y;
	protected float startScale;
	
	[SerializeField]
	protected float speedMultiplier;

	protected Vector2 scale;
	protected Vector2 direction;
	
	protected override void Start()
	{
		base.Start();

		scale = new Vector2(transform.localScale.x, transform.localScale.y);

		startScale = transform.localScale.x;
	}

	protected virtual void FixedUpdate()
	{
		speed = speedMultiplier;
		mathSpeed += Time.deltaTime * speedMultiplier;

		if(!hasBeenHooked)
		{
			Movement();
		}
	}
	
	protected virtual void Movement()
	{
		
	}

    public void PickUp(Transform newParent)
    {
        transform.parent = newParent;
        hasBeenHooked = true;
    }

    public int GetPointWorth()
    {
        return fishPoints;
    }
}
