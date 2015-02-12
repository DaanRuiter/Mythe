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
	
#region Serialized variables
	[SerializeField]
	protected float speedMultiplier;

	[SerializeField]
	protected int fishPoints;
#endregion

	protected Vector2 scale;
	protected Vector2 direction;

	protected virtual void Start()
	{
		scale = new Vector2(transform.localScale.x, transform.localScale.y);

		startScale = transform.localScale.x;

		hasBeenHooked = false;
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
}
